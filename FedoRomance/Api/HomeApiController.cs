using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FedoRomance.Data;
using FedoRomance.Web.Models;
using System.Web.Mvc;
using System.Web.Security;

namespace FedoRomance.Web.Api
{
    public class HomeApiController : ApiController
    {
        public static List<Post> GetPosts()
        {
            using (var context = new DatabaseEntities())
            {
                var posts = new List<Post>();
                var getPosts = from p in context.Posts
                             orderby p.PostedDate descending
                             select p;
                posts = getPosts.ToList();
                return posts;
            }
        }

        public void Post(string message)
        {
            using (var context = new DatabaseEntities()) {
                Post newPost= new Post {
                    Message = message,
                    PostedBy = User.Identity.Name,
                    PostedDate = DateTime.Now.ToString()
                };
                context.Posts.Add(newPost);
                context.SaveChanges();
            }
        }

    }
}
