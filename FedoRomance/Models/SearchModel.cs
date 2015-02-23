using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FedoRomance.Web.Models
{
    public class SearchModel {
        
        [Display]
        [Required(ErrorMessage = "You have to search for something, you silly goose!")]
        public string SearchValue { get; set; }
    }
}