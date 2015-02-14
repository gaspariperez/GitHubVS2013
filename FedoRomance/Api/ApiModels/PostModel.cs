using System.Collections.Generic;
using FedoRomance.Data;

namespace FedoRomance.Web.Models
{
    public class PostModel
    {
        public string Message { get; set; }
        public string Poster { get; set; }
        public string Receiver { get; set; }

        public List<PostModel> PostList { get; set; } 

	}
}