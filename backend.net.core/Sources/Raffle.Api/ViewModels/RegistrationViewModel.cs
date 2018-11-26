using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Raffle.Api.ViewModels
{
    [JsonObject("data")]
    public class RegistrationViewModel
    {
        [Required, EmailAddress, JsonProperty("email")]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required, Compare("Password", ErrorMessage = "Confirm password doesn't match, Type again !")]
        [JsonProperty("passwordConfirm")]
        public string PasswordConfirm { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }
    }
}
