using ReNew.Misc.Reflect;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReNew.Misc.RoundManage
{
    public class RoundManager
    {
        public BiDictionary<int, IRound> roundpair = new BiDictionary<int, IRound>();
        public RoundManager()
        {
            List<IRound> roundtypes = new ClassSearch("ReNew.Misc.RoundManage.Rounds").Search<IRound>();
        }
    }
}
