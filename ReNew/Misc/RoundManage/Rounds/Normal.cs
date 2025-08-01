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
        public string RoundTypeName { get; } = "normal";
        public int RoundId { get; } = 0;
        public bool OverrideEvent { get; } = false;
        public double Chance { get; set; } = 1.0;
        public void Register()
        {}

        public void UnRegister()
        {}
    }
}
