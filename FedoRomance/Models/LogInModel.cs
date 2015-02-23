using System.ComponentModel.DataAnnotations;

namespace FedoRomance.Web.Models
{
    public class LogInModel
    {
        [Display(Name = "Username: ")]
        [Required(ErrorMessage = "Enter your username!")]
        public string Username { get; set; }

        [Display(Name = "Password: ")]
        [Required(ErrorMessage = "Enter your password!")]
        public string Password { get; set; }
	}
}