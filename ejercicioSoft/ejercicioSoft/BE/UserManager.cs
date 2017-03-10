using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ejercicioSoft.Models;

namespace ejercicioSoft.BE
{
    public class UserManager
    {
        public static List<UserModel> users = new List<UserModel>()
        {
            new UserModel() { username = "jorge@jorge.com", password="123", role="Admin" },
            new UserModel() { username = "areli@areli.com", password="132", role="User" }
        };
        public UserModel isValid(UserModel um)
        {
            var result = (from u in users
                          where u.username == um.username && u.password == um.password
                          select u).SingleOrDefault();
            return result;    
        }
    }
}