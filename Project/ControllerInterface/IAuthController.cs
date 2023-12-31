﻿using Project.Enum;
using Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.ControllerInterface
{
    public interface IAuthController
    {
        User Login(string username, string password);
        bool Register(User user, Role role);
        void Logout();
        bool ValidateUser(string username);
    }
}
