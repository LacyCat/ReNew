using ReNew.Misc.RoundManage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ReNew.Misc.Reflect
{
    public class ClassSearch
    {
        public string SearchNameSpace { get; }

        public ClassSearch(string n)
        {
            this.SearchNameSpace = n;
        }

        public List<TInterface> Search<TInterface>() where TInterface : class
        {
            Type targetInterface = typeof(TInterface);

            return Assembly.GetExecutingAssembly()
                .GetTypes()
                .Where(t => t.IsClass && t.Namespace == SearchNameSpace && targetInterface.IsAssignableFrom(t))
                .Select(t => Activator.CreateInstance(t) as TInterface)
                .Where(instance => instance != null)
                .ToList();
        }
    }
}
