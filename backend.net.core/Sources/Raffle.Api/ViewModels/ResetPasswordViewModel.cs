using System.ComponentModel.DataAnnotations;

namespace Raffle.Api.ViewModels
{
    public class ResetPasswordViewModel
    {
        [Required]
        public string UserId { get; set; }

        [Required]
        public string Code { get; set; }

        [Required]
        public string Password { get; set; }

        [Required, Compare("Password", ErrorMessage = "Confirm password doesn't match, Type again !")]
        public string PasswordConfirm { get; set; }
    }
}
