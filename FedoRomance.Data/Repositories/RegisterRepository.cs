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
            using (var user = new DatabaseEntities())
            {
                User newUser = new User
                {
                    Name = name,
                    Age = age,
                    Gender = gender,
                    About = about,
                    Username = username,
                    Password = password,
                    Visible = visible,
                    Logged = 0
                };
                
                user.SaveChanges();
            }
        }
    }
}
