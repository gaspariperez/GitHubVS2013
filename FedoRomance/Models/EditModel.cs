using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace FedoRomance.Web.Models
{
    public class EditModel
    {
        [Display(Name = "Namn")]
        [Required(ErrorMessage = "Ange ett namn")]
        public string Name { get; set; }

        public int Age { get; set; }

        public string Gender { get; set; }

        public string About { get; set; }

        public int Visible { get; set; }

        public bool BoolValue {
            get { return Visible == 1; }
            set { Visible = value ? 1 : 0; }
        }

        public string Picture { get; set; }
        
    }
}
