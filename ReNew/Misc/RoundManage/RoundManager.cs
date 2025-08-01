using Achievements.Handlers;
using Exiled.API.Features;
using Exiled.Events.EventArgs.Server;
using Exiled.Events.Handlers;
using ReNew.Misc.Reflect;
using ReNew.Misc.RoundManage.Rounds;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReNew.Misc.RoundManage
{
    public class RoundManager
    {
        public int MaxId = 0;
        public BiDictionary<int, IRound> roundpair = new BiDictionary<int, IRound>();
        public Random random = new Random();
        public IRound now = new Normal();
        public Main plugin;
        public RoundManager(Main p)
        {
            List<IRound> roundtypes = new ClassSearch("ReNew.Misc.RoundManage.Rounds").Search<IRound>();
            foreach (IRound rd in roundtypes)
            {
                roundpair.Add(rd.RoundId, rd);
            }
            this.plugin = p;
        }
        public IRound Pick()
        {
            if (roundpair.TryGetByKey(random.Next(0, MaxId + 1), out IRound r))
            {
                return r;
            }
            else
            {
                return new Normal();
            }
        }
        public void Register()
        {
            Exiled.Events.Handlers.Server.RoundStarted += OnStart;
            Exiled.Events.Handlers.Server.RoundEnded += OnEnd;
        }
        public void UnRegister()
        {
            Exiled.Events.Handlers.Server.RoundStarted -= OnStart;
            Exiled.Events.Handlers.Server.RoundEnded -= OnEnd;
        }
        public void OnStart()
        {
            this.now = Pick();
            if (now.OverrideEvent)
            {
                plugin.UnRegisterNRQ();   
            }
            now.Register();
        }
        public void OnEnd(RoundEndedEventArgs args)
        {
            now.UnRegister();
            if (now.OverrideEvent)
                plugin.RegisterNRQ();
        }
    }
}
