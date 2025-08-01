using ReNew.Misc.RoundManage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReNew.Misc.RoundManage.Rounds
{
    public class Normal : IRound
    {
        public string RoundTypeName => "normal";
        public int RoundId => 0;
        public bool OverrideEvent => false;
        public double Chance { get; set; } = 0.75f;
        public void Register()
        {}

        public void UnRegister()
        {}
    }
}
