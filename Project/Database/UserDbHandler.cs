﻿using Newtonsoft.Json;
using Project.BusinessLayer;
using Project.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Database
{
    internal class UserDbHandler : DbHandler
    {
        private static UserDbHandler userDbInstance;
        private static string _user_path;
        public List<User> listOfUsers { get; set; }
        public static UserDbHandler UserDbInstance
        {
            get
            {
                if (userDbInstance == null)
                {
                    userDbInstance = new UserDbHandler();
                }
                return userDbInstance;
            }
        }
        private UserDbHandler()
        {
            listOfUsers = new List<User>();
             _user_path = @"C:\Users\vranjan\OneDrive - WatchGuard Technologies Inc\Desktop\Practice\Project\Users.json";

            try
            {
                string userFileContent = File.ReadAllText(_user_path);
                listOfUsers = JsonConvert.DeserializeObject<List<User>>(userFileContent)!;
            }
            catch
            {
                Error.UnexpectedError();
            }
    }
       
        public override bool AddEntry(Object obj)
        {
            if (obj is User)
            {
                listOfUsers.Add((User)obj);
                if (UpdateEntry<User>(_user_path, listOfUsers))
                {
                    return true;
                }
                return false;
            }
            return false;

        }

       
    }
}
