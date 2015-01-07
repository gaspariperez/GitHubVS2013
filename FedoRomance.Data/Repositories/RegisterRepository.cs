using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FedoRomance.Data.Repositories 
{
    public class RegisterRepository 
    {
        public static List<User> LogIn(string username)
        {
            using (var user = new DatabaseEntities())
            {
                
            }
            return null;
        } 
    }
}
