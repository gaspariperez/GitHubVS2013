using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FedoRomance.Data.Repositories
{
    public class IndexRepository {
        public static User GetUsers(string exampleUser)
        {
            using (var context = new DatabaseEntities()) {
                var user = context.Users.FirstOrDefault(x => x.Username.Equals(exampleUser));
                return user;
            }
        }
    }
}
