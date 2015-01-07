using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FedoRomance.Data.Repositories
{
    public class SearchRepository
    {
        public static List<User> Search(string name)
        {
            using (var user = new DatabaseEntities())
            {
                List<User> result = new List<User>();
                var search = from r in user.Users
                             where r.Name.Contains(name)
                             select r;

                result = search.ToList();
                return result;
            }
        }





    }
}
