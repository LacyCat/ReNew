using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReNew.Misc.Translation
{
    public class Translation
    {
        public static BiDictionary<string, string> roundtranslate = new BiDictionary<string, string>();
        static Translation()
        {
            roundtranslate.Add("normal", "일반");
        }
        
    }
}
