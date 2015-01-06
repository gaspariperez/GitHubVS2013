using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FedoRomance.Data;
using FedoRomance.Web.Models;

namespace FedoRomance.Web.Api
{
    public class HomeApiController : ApiController
    {
        public static List<string> Search(string name)
        {
            using (var user = new DatabaseEntities())
            {
                var result = new List<string>();
                var search = from r in user.Users
                             where r.Firstname.Contains(name)
                             select r.ToString();

                foreach (var item in search)
                {
                    result.Add(item);
                }
                return result;
            }
        }
 




    }
}
