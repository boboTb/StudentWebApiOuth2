using StudentWebApiOuth2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentWebApiOuth2.Service
{
    public class UserService
    {
        public User GetUser(string name, string pass)
        {
            User user = new User { id = "1", Name = "Admin", Password = "pass123" };
            return user;
        }
    }
}