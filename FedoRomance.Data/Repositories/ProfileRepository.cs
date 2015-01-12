using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FedoRomance.Data.Repositories {
    public class ProfileRepository {
        public static User GetProfile(string username)
        {
            using (var context = new DatabaseEntities()) {
                var user = context.Users.FirstOrDefault(x => x.Username.Equals(username));
                return user;
            }
        }




    }
}
