using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FedoRomance.Web.Models
{
    public class ProfileModel {

        public string Username { get; set; }

        public string Name { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public string About { get; set; }
        public string Picture { get; set; }


        public int PostId { get; set; }
        public string Message { get; set; }
        public string PostedBy { get; set; }
        public string PostedDate { get; set; }
        public string UserWall { get; set; }
	}
}