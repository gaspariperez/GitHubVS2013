using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace FedoRomance.Data.Repositories {
    public class EditRepository {

        public static void EditUser(string userToUpdate, string name, int age, string gender, string about, int visible)
        {
            using (var context = new DatabaseEntities())
            {
                var user = context.Users.FirstOrDefault(x => x.Username == userToUpdate);
                if (name != null)
                {
                    user.Name = name;
                }
                user.Age = age;
                user.Gender = gender;
                user.About = about;
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

        public static void UploadUserPic(string userToUpdate, string picture)
        {
            using (var context = new DatabaseEntities())
            {
                var user = context.Users.FirstOrDefault(x => x.Username == userToUpdate);
                user.Picture = picture;
                context.SaveChanges();
            }
        }

        public static void NewPassword(string userToUpdate, string currentPassword, string newPassword)
        {
            using (var context = new DatabaseEntities()) {
                var user = context.Users.FirstOrDefault(x => x.Username == userToUpdate);
                if (currentPassword == user.Password && newPassword != null) {
                    user.Password = newPassword;
                    context.SaveChanges();
                }
            }
        }

        public static bool PasswordCheck(string username, string password)
        {
            using (var context = new DatabaseEntities())
            {
                var user = context.Users.FirstOrDefault(x => x.Username == username);
                if (password == user.Password) {
                    return true;
                }
                return false;
            }
        }
    }
}
