using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FedoRomance.Web.Models
{
    public class SearchModel {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Region { get; set; }
        public string Gender { get; set; }

    }
}