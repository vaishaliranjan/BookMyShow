using Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.ControllerInterface
{
    public interface IGetByUsername<T> where T : class
    {
        T GetByUsername(string username);
    }
}
