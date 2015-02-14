using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FedoRomance.Data;
using FedoRomance.Data.Repositories;
using FedoRomance.Web.Models;

namespace FedoRomance.Web.Api
{
    public class PostsController : ApiController
    {

        [HttpPost]
        public void Post(PostModel post)
        {
            var poster = GetProfile(post.Poster);
            var reciever = GetProfile(post.Receiver);

            PostRepository.AddPost(post.Message, poster.UID, reciever.UID, post.Poster, post.Receiver);
        }

        public static User GetProfile(string username)
        {
            using (var context = new DatabaseEntities())
            {
                var user = context.Users.FirstOrDefault(x => x.Username.Equals(username));
                return user;
            }
        }

        [HttpGet]
        public List<PostModel> GetPosts(string username)
        {
            var getPosts = PostRepository.GetPosts(username);
            var postList = new List<PostModel>();

            foreach (var item in getPosts)
            {
                var post = new PostModel
                {
                    Message = item.Message,
                    Poster = item.Poster
                };
                postList.Add(post);
            }
            return postList;
        }
        

        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }
        
        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}