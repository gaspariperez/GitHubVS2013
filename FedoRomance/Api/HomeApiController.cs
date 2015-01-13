using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FedoRomance.Data;
using FedoRomance.Data.Repositories;
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
                             select p;
                
                return getPosts.ToList();
            }
        }

        

        [System.Web.Http.HttpPost]
        public void Post(PostModel post)
        {
            PostRepository.AddPost(post.Message, post.PostedBy, post.UserWall);
        }
    }
}
