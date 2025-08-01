using Exiled.API.Enums;
using Exiled.API.Features;
using Exiled.API.Features.DamageHandlers;
using Exiled.Events.EventArgs.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace ReNew.Events
{
    public class Kick
    {
        private readonly bool debug;
        public Kick(Plugin<Configs> p)
        {
            this.debug = p.Config.Debug;
        }
        public void Register()
        {
            Exiled.Events.Handlers.Player.TogglingNoClip += OnTogglingNoClip;
        }
        public void Unregister()
        {
            Exiled.Events.Handlers.Player.TogglingNoClip -= OnTogglingNoClip;
        }
        public void OnTogglingNoClip(TogglingNoClipEventArgs ev)
        {
            ev.IsAllowed = false; // 노클립은 막고 Alt 누름만 감지

            float radius = 2f;
            float damage = 10f;
            foreach (Player target in Player.List)
            {
                if (target == ev.Player || !target.IsAlive)
                    continue;

                float distance = Vector3.Distance(ev.Player.Position, target.Position);
                if (distance <= radius)
                {
                    ReferenceHub attackerHub = ev.Player.ReferenceHub;

                    target.Hurt(attacker:ev.Player,damage:damage);
                }
            }
        }
    }
}
