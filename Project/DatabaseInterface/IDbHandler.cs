using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DatabaseInterface
{
    public interface IDbHandler<T> where T : class
    {
        bool AddEntry(T obj, List<T> list, string path);
        bool UpdateEntry(string path, List<T> list);
    }
}
