using Exiled.API.Features;
using MEC;
using ReNew.Misc.RoundManage;
using System.Collections.Generic;

namespace ReNew.Misc.BroadCast
{
    public class BroadcastManager
    {
        private bool isBroadcastRunning = false;
        private CoroutineHandle broadcastCoroutine = default;

        public void StartLobbyBroadcast(IRound now)
        {
            if (isBroadcastRunning)
                return;

            isBroadcastRunning = true;
            broadcastCoroutine = Timing.RunCoroutine(BroadcastLoop(now));
        }

        public void StopLobbyBroadcast()
        {
            if (!isBroadcastRunning)
                return;

            isBroadcastRunning = false;

            if (Timing.IsRunning(broadcastCoroutine))
                Timing.KillCoroutines(broadcastCoroutine);

            broadcastCoroutine = default;

            foreach (var player in Player.List)
                player.ClearBroadcasts();
        }

        private IEnumerator<float> BroadcastLoop(IRound now)
        {
            while (isBroadcastRunning)
            {
                foreach (var player in Player.List)
                    player.Broadcast(5, $"<color=yellow>로비 상태입니다! 곧 게임이 시작됩니다.</color>\n이번 라운드는.... {now.RoundTypeName} !");

                yield return Timing.WaitForSeconds(5f);
            }
        }
    }
}
