using System.ComponentModel.DataAnnotations;

namespace Raffle.Api.ViewModels
{
    public class ForgotPasswordViewModel
    {
        [Required, EmailAddress]
        public string Email { get; set; }
    }
}
