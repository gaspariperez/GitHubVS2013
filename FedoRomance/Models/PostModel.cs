using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FedoRomance.Web.Models
{
    public class PostModel
    {
        public int PostId { get; set; }
        public string Message { get; set; }
        public string PostedBy { get; set; }
        public string PostedDate { get; set; }
	}
}