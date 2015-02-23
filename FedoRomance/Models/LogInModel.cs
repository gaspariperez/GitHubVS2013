using System.ComponentModel.DataAnnotations;

namespace FedoRomance.Web.Models
{
    public class LogInModel
    {
        [Display(Name = "Username: ")]
        [Required]
        public string Username { get; set; }

        [Display(Name = "Password: ")]
        [Required]
        public string Password { get; set; }
	}
}