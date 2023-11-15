using Project.Enum;
using Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.ControllerInterface
{
    internal interface IAuthController
    {
        User Login(string username, string password);
        void Register(User user, Role role);
        void Logout();
        bool ValidateUser(string username);
    }
}
