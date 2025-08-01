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
        public static bool enabled = true;
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
            var rounds = roundpair.Values.ToList();

            // 총 확률 합계를 계산
            double totalChance = rounds.Sum(r => r.Chance);

            // 확률 누적분포 계산
            double roll = random.NextDouble() * totalChance;
            double cumulative = 0.0;

            foreach (var round in rounds)
            {
                cumulative += round.Chance;
                if (roll <= cumulative)
                {
                    return round;
                }
            }

            // 만일 확률 누적 오류가 발생한 경우 기본 라운드 반환
            return new Normal();
        }

        public void Register()
        {
            Exiled.Events.Handlers.Server.WaitingForPlayers += OnStart;
            Exiled.Events.Handlers.Server.RoundEnded += OnEnd;
        }
        public void UnRegister()
        {
            Exiled.Events.Handlers.Server.WaitingForPlayers -= OnStart;
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
            string nowname = "알 수 없음";
            Translation.Translation.roundtranslate.TryGetByKey(now.RoundTypeName, out nowname);
            foreach (var player in Exiled.API.Features.Player.List)
            {
               
                player.Broadcast(duration: 9999, "이번 라운드는... " + nowname);
            }
        }
        public void OnEnd(RoundEndedEventArgs args)
        {
            now.UnRegister();
            if (now.OverrideEvent)
                plugin.RegisterNRQ();
        }
    }
}
