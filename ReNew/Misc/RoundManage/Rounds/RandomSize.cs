using Exiled.API.Features;
using MEC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReNew.Misc.RoundManage.Rounds
{
    public class RandomSize : IRound
    {
        public string RoundTypeName => "randomsize";

        public int RoundId => 1;

        public bool OverrideEvent => false;

        public double Chance { get; set; } = 0.125f;

        public void Register()
        {
            Exiled.Events.Handlers.Server.RoundStarted += OnRoundStarted;
        }

        public void UnRegister()
        {
            Exiled.Events.Handlers.Server.RoundStarted -= OnRoundStarted;
        }
        public void OnRoundStarted()
        {
            Random rand = new Random();
            Timing.CallDelayed(2f, () => {
                List<Player> players = Player.List.ToList();
                foreach (Player p in players)
                {
                    float x = (float)rand.NextDouble() * 1.4f + 0.1f;
                    float y = (float)rand.NextDouble() * 1.4f + 0.1f;
                    float z = (float)rand.NextDouble() * 1.4f + 0.1f;
                    p.Scale = new UnityEngine.Vector3(x, y, z);
                }
            });
        }
    }
}
