using Exiled.API.Extensions;
using Exiled.Events.EventArgs.Player;
using MEC;
using PlayerRoles;
using ReNew.Feature;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReNew.Misc.RoundManage.Rounds
{
    public class Camcouflage : IRound
    {
        public string RoundTypeName => "camouflage";

        public int RoundId => 2;

        public bool OverrideEvent => false;

        public double Chance { get; set; } = 0.125f;

        public void Register()
        {
            Exiled.Events.Handlers.Player.Spawned += OnSpawned;
        }

        public void UnRegister()
        {
            Exiled.Events.Handlers.Player.Spawned -= OnSpawned;
        }
        public void OnSpawned(SpawnedEventArgs ev)
        {
            
            ShapedRoleEnum sre = new ShapedRoleEnum();
            sre.shapedroles.ShuffleList();
            RoleTypeId one = sre.shapedroles[UnityEngine.Random.Range(0,sre.shapedroles.Count)];
            Timing.CallDelayed(2f, () => { 
                ev.Player.ChangeAppearance(one);
            });
        }
    }
}
