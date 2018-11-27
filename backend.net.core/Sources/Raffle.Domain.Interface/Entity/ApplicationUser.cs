using Microsoft.AspNetCore.Identity;

namespace Raffle.Domain.Interface.Entity
{
    public class ApplicationUser: IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
