using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace FedoRomance.Web.Models
{
    public class EditViewModel
    {
        [Display(Name = "Age")]
        public int Age { get; set; }

        [Display(Name = "Length")]
        public int Length { get; set; }

        [Display(Name = "Weight")]
        public int Weight { get; set; }

        [Display(Name = "Region")]
        public string Region { get; set; }

        [Display(Name = "Gender")]
        public string Gender { get; set; }




    }
}