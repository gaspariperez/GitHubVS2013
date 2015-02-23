using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Register;


namespace FedoRomance.Web.Models
{
    public class RegisterModel
    {

        [Display(Name = "Name", ResourceType = typeof(Register.Register))]
        [Required(ErrorMessage = "Ange ett namn")]
        public string Name { get; set; }

        [Display(Name = "Age" , ResourceType =  typeof(Register.Register))]
        public int Age { get; set; }

        [Display(Name = "Gender", ResourceType = typeof(Register.Register))]
        public string Gender { get; set; }

        [Display(Name = "About", ResourceType =  typeof(Register.Register))]
        public string About { get; set; }

        [Display(Name = "Username", ResourceType = typeof(Register.Register))]
        [Required(ErrorMessage = "Ange ett användarnamn")]
        public string Username { get; set; }

        [Display(Name = "Password", ResourceType = typeof(Register.Register))]
        [Required(ErrorMessage = "Ange ett lösenord")]
        public string Password { get; set; }

        [Display(Name = "PasswordMatch", ResourceType = typeof(Register.Register))]
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