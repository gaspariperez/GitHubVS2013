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
        public static IEnumerable<Post> GetPosts()
        {
            using (var context = new DatabaseEntities())
            {
                var getPosts = from p in context.Posts
                             orderby p.PostedDate descending
                             select p;
                
                return getPosts.ToList();
            }
        }

        public HttpResponseMessage Post(ProfileModel post)
        {

            if (ModelState.IsValid)
            {
                using (var context = new DatabaseEntities())
                {
                    Post newPost = new Post
                    {
                        Message = post.Message,
                        PostedBy = User.Identity.Name,
                        PostedDate = DateTime.Now.ToString()
                    };
                    context.Posts.Add(newPost);
                    context.SaveChanges();
                }
            }
            
        }

    }
}
