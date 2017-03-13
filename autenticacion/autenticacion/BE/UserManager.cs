using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using autenticacion.Models;

namespace autenticacion.BE
{
    public class UserManager
    {
        public static List<UserModel> users = new List<UserModel>()
        {
            new UserModel() { username = "jorge@jorge.com", password="123", role="Admin", image_path="/Content/Images/jorge.jpg" },
            new UserModel() { username = "areli@areli.com", password="123", role="User", image_path="/Content/Images/areli.jpg" }
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