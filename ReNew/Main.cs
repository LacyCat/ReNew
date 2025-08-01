using Exiled.API.Features;
using ReNew.Events;
using ReNew.Misc.RoundManage;

namespace ReNew
{
    public class Main : Plugin<Configs>
    {
        public SpawnSans ss { get; set; }
        public ProximityChat pc { get; set; }
        public RoundManager manager { get; }
        public Kick kick { get; set; }
        public Main()
        {
            this.Config.Debug = false;
            ss = new SpawnSans(this);
            pc = new ProximityChat(this);
            manager = new RoundManager(this);
            kick = new Kick(this);
        }
        public override void OnEnabled()
        {
            base.OnEnabled();
            RegisterNRQ();
            manager.Register();
        }
        public override void OnDisabled()
        {
            base.OnDisabled();
            UnRegisterNRQ();
            manager.UnRegister();
        }
        public void RegisterNRQ()
        {
            ss.Register();
            pc.Register();
        }
        public void UnRegisterNRQ()
        {
            ss.Unregister();
            pc.Unregister();
        }
        public void RegisterRQ()
        {
            kick.Register();
        }
        public void UnregisterRQ()
        {
            kick.Unregister();
        }
    }
}
