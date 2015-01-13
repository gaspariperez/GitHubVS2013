using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using sprak;

namespace FedoRomance.Web.Models
{
    public class RegisterModel
    {

        [Display(Name = "Name", ResourceType = typeof(Language))]
        [Required(ErrorMessage = "Ange ett namn")]
        public string Name { get; set; }

        [Display(Name = "Age" , ResourceType =  typeof(Language))]
        public int Age { get; set; }

        [Display(Name = "Gender", ResourceType = typeof(Language))]
        public string Gender { get; set; }

        [Display(Name = "About", ResourceType =  typeof(Language))]
        public string About { get; set; }

        [Display(Name = "Username", ResourceType = typeof(Language))]
        [Required(ErrorMessage = "Ange ett användarnamn")]
        public string Username { get; set; }

        [Display(Name = "Password",ResourceType = typeof(Language))]
        [Required(ErrorMessage = "Ange ett lösenord")]
        public string Password { get; set; }

        [Display(Name = "PasswordMatch",ResourceType = typeof(Language))]
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