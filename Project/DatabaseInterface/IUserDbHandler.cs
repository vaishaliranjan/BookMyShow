using Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DatabaseInterface
{
    public interface IUserDbHandler
    {
        List<User> ListOfUsers { get; set; }
        bool AddUser(User user);
    }
}
