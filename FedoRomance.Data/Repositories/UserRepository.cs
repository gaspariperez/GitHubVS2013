using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Metadata.Edm;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace FedoRomance.Data.Repositories {
    public class UserRepository {

        public static User TestLogIn(string username, string password)
        {
            using (var context = new DatabaseEntities())
            {
                return context.Users.FirstOrDefault(
                    x =>
                        x.Username.Equals(username) &&
                        x.Password.Equals(password));
            }
        }
    }
}
