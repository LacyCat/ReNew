using Exiled.API.Features;
using LiteNetLib4Mirror.Open.Nat;
using MEC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReNew.Events
{
    public class SpawnSans
    {
        private readonly bool debug;

        public SpawnSans(Plugin<Configs> p)
        {
            this.debug = p.Config.Debug;
        }

        public void Register()
        {
            Exiled.Events.Handlers.Server.RoundStarted += Auto;
        }

        public void Unregister()
        {
            Exiled.Events.Handlers.Server.RoundStarted -= Auto;
        }

        public void Auto()
        {
            Timing.CallDelayed(2f, () => {
                List<Exiled.API.Features.Player> partial_players = Exiled.API.Features.Player.List.Where(p => p.IsScp == true).ToList();
                if (partial_players.Count == 0)
                {
                    return;
                }
                else
                {
                    Pick(partial_players);
                }
            });
        }

        private void Pick(List<Player> list)
        {
            Exiled.API.Features.Player one = list[UnityEngine.Random.Range(0, list.Count)];
            if (UnityEngine.Random.value <= 0.5f)
            {
                Timing.CallDelayed(0.5f, () =>
                {
                    one.Role.Set(PlayerRoles.RoleTypeId.Scp3114);
                });
            }
        }
    }
}
