using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FedoRomance.Data;

namespace FedoRomance.Web.Models
{
    public class PostModel
    {
        public string Message { get; set; }
        public string PostedBy { get; set; }
        public string UserWall { get; set; }
	}
}