using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReNew.Misc.RoundManage
{
    public interface IRound
    {
        string RoundTypeName { get; }
        int RoundId { get; }
        bool OverrideEvent { get; }
        void Register();
        void UnRegister();
    }
}
