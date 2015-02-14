using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FedoRomance.Data.Repositories
{
    public class PostRepository
    {
        public static void AddPost(string message, int postedBy, int postedTo, string poster, string receiver)
        {
            using (var context = new DatabaseEntities())
            {
                var newPost = new Post
                {
                    Message = message,
                    PostedBy = postedBy,
                    PostedTo = postedTo,
                    Poster = poster,
                    Receiver = receiver
                };
                context.Posts.Add(newPost);
                context.SaveChanges();                
            }
        }

        public static List<Post> GetPosts(string username)
        {
            using (var context = new DatabaseEntities())
            {
                var result = context.Posts
                    .Where(x => x.Receiver.Equals(username))
                    .ToList();

                return result;
            }
        } 

    }
}
