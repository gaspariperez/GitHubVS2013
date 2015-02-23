using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FedoRomance.Web.Models
{
    public class EditPasswordModel
    {
        [Display(Name = "Current password")]
        [Required(ErrorMessage = "Enter your current password.")]
        public string CurrentPassword { get; set; }

        [Display(Name = "New password")]
        [Required(ErrorMessage = "Enter a new password.")]
        public string NewPassword { get; set; }

        [Display(Name = "Confirm new password")]
        [Required(ErrorMessage = "Enter the new password again.")]
        [System.Web.Mvc.Compare("NewPassword", ErrorMessage = "Passwords don't match!")]
        public string NewPasswordMatch { get; set; }
    }
}