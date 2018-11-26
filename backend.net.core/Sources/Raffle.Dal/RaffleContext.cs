using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Raffle.Domain.Interface.Entity;

namespace Raffle.Dal
{
    public class RaffleContext : IdentityDbContext<ApplicationUser>
    {
        public RaffleContext(DbContextOptions options)
            : base(options)
        {
        }

        //public DbSet<Customer> Customers { get; set; }
    }
}
