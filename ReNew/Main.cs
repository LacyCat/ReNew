using Exiled.API.Features;
using ReNew.Events;

namespace ReNew
{
    public class Main : Plugin<Configs>
    {
        public SpawnSans ss { get; set; }
        public ProximityChat pc { get; set; }

        public Main()
        {
            this.Config.Debug = false;
            ss = new SpawnSans(this);
            pc = new ProximityChat(this);
        }
        public override void OnEnabled()
        {
            base.OnEnabled();
            ss.Register();
            pc.Register();
        }
        public override void OnDisabled()
        {
            base.OnDisabled();
            ss.Unregister();
            pc.Unregister();
        }
        public void UnRegisterNRQ()
        {
            ss.Unregister();
            pc.Unregister();
        }
        public void RegisterNRQ()
        {
            ss.Register();
            pc.Register();
        }
    }
}
