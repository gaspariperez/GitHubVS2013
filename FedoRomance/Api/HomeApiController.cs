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
            try
            {
                if (ModelState.IsValid)
                {
                    using (var context = new DatabaseEntities())
                    {
                        var newPost = new Post
                        {
                            Message = post.Message,
                            PostedBy = User.Identity.Name,
                            PostedDate = DateTime.Now.ToString(),
                            UserWall = post.Username
                        };
                        context.Posts.Add(newPost);
                        context.SaveChanges();
                        return Request.CreateResponse(HttpStatusCode.OK);
                    }
                }

                else
                {
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, "Invalid Model");
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
