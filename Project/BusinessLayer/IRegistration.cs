using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BusinessLayer
{
    public interface IRegistration
    {
        void Register(int id, string name, string username, string email, Role role, string password);
    }
}
