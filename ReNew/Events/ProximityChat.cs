using System.Collections.Generic;
using Exiled.API.Features;
using Exiled.Events.EventArgs.Player;
using PlayerRoles.FirstPersonControl;
using PlayerRoles.Spectating;
using PlayerRoles.Voice;
using UnityEngine;
using VoiceChat;
using VoiceChat.Networking;

namespace ReNew.Events
{
    public class ProximityChat
    {
        private readonly bool debug;

        public ProximityChat(Plugin<Configs> p)
        {
            debug = p.Config.Debug;
        }

        public void Register()
        {
            Exiled.Events.Handlers.Player.VoiceChatting += OnPlayerUsingVoiceChat;
        }

        public void Unregister()
        {
            Exiled.Events.Handlers.Player.VoiceChatting -= OnPlayerUsingVoiceChat;
        }

        public void OnPlayerUsingVoiceChat(VoiceChattingEventArgs args)
        {
            if (args.VoiceMessage.Channel != VoiceChatChannel.ScpChat)
                return;

            if (debug) Log.Info(args.Player.Nickname + " Triggering SCP Proximity Voice");
            SendProximityMessage(args.VoiceMessage);

            args.IsAllowed = false;
        }

        private void SendProximityMessage(VoiceMessage msg)
        {
            foreach (ReferenceHub referenceHub in ReferenceHub.AllHubs)
            {
                if (referenceHub.roleManager.CurrentRole is SpectatorRole && !msg.Speaker.IsSpectatedBy(referenceHub))
                    continue;

                IVoiceRole voiceRole2 = referenceHub.roleManager.CurrentRole as IVoiceRole;
                if (voiceRole2 == null)
                    continue;

                if (Vector3.Distance(msg.Speaker.transform.position, referenceHub.transform.position) >= 7f)
                    continue;

                if (voiceRole2.VoiceModule.ValidateReceive(msg.Speaker, VoiceChatChannel.Proximity) is VoiceChatChannel.None)
                    continue;

                msg.Channel = VoiceChatChannel.Proximity;
                if (debug) Log.Info("Sended!");
                referenceHub.connectionToClient.Send(msg);
            }
        }
    }
}
