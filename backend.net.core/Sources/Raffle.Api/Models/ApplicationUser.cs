using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Raffle.Api.Models
{
    public class ApplicationUser: IdentityUser
    {
        public string FirstName { get; set; }
    }
}
