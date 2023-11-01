using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Database
{
    internal abstract class DbHandler
    {
        public abstract bool AddEntry(Object obj);
        public bool UpdateEntry<T>(string path, List<T> list)
        {
            try
            {
                var jsonFormattedContent = Newtonsoft.Json.JsonConvert.SerializeObject(list);
                File.WriteAllText(path, jsonFormattedContent);
            }
            catch
            {
                return false;
            }
            return true;
        }
       
    }
}
