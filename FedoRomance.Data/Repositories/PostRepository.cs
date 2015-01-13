using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FedoRomance.Data.Repositories
{
    public class PostRepository
    {
        public static void AddPost(string message, string postedBy, string userWall)
        {
            using (var context = new DatabaseEntities())
            {
                Post newPost = new Post
                {
                    Message = message,
                    PostedBy = postedBy,
                    UserWall = userWall
                };

                context.Posts.Add(newPost);
                context.SaveChanges();
            }
        }
    }
}
