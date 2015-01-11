using System.ComponentModel.DataAnnotations;

namespace FedoRomance.Web.Models
{
    public class LogInModel
    {
        [Display(Name = "Användarnamn: ")]
        [Required]
        public string Username { get; set; }

        [Display(Name = "Lösenord: ")]
        [Required]
        public string Password { get; set; }
	}
}