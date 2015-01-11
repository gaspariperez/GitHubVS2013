using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FedoRomance.Web.Models
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "Ange ett namn")]
        public string Name { get; set; }

        public int Age { get; set; }

        public string Gender { get; set; }

        public string About { get; set; }

        [Required(ErrorMessage = "Ange ett användarnamn")]
        public string Username { get; set; }

        [Display(Name = "Lösenord")]
        [Required(ErrorMessage = "Ange ett lösenord")]
        public string Password { get; set; }

        [Display(Name = "Lösernordet igen")]
        [System.ComponentModel.DataAnnotations.Compare("Password", ErrorMessage = "Matchar inte!")]
        public string PasswordMatch { get; set; }

        public int Visible { get; set; }

        public bool BoolValue
        {
            get { return Visible == 1; }
            set { Visible = value ? 1 : 0; }
        }
    }
}