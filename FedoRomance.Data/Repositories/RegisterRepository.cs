using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FedoRomance.Data.Repositories 
{
    public class RegisterRepository 
    {
        public static void Register(string name, int age, string gender, string about, string username, string password, int visible) {
            using (var context = new DatabaseEntities())
            {
                    User newUser = new User {
                        Name = name,
                        Age = age,
                        Gender = gender,
                        About = about,
                        Username = username,
                        Password = password,
                        Visible = visible,
                    };             
                    context.Users.Add(newUser);
                    context.SaveChanges();
            }
        }

        public static bool UsernameCheck(string username)
        {
            using (var context = new DatabaseEntities())
            {
                var usernameCheck = context.Users.FirstOrDefault(x => x.Username.Equals(username));

                if (usernameCheck == null)
                {
                    return false;
                }
                return true;
            }
        }
    }
}