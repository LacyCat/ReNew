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
        public Main()
        {
            this.Config.Debug = false;
            ss = new SpawnSans(this);
            pc = new ProximityChat(this);
            manager = new RoundManager(this);
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
        
    }
}
