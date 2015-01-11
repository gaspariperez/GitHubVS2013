using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FedoRomance.Data.Repositories {
    public class EditRepository {

        public static void EditUser(string userToUpdate, string name, int age, string gender, string about, string password, int visible)
        {
            using (var context = new DatabaseEntities())
            {
                var user = context.Users.FirstOrDefault(x => x.Username == userToUpdate);
                user.Name = name;
                user.Age = age;
                user.Gender = gender;
                user.About = about;
                user.Password = password;
                user.Visible = visible;
                context.SaveChanges();
            }
        }

        public static User GetUser(string username)
        {
            using (var context = new DatabaseEntities()) {
                var user = context.Users.FirstOrDefault(x => x.Username.Equals(username));
                return user;
            }
        }

    }
}
