using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FedoRomance.Web.Models
{
    public class SearchModel {
        
        

        public string Username { get; set; }

        [Display]
        [Required(ErrorMessage = "DU måste söka på något")]
        public string Name { get; set; }
    }
}