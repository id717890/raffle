using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Raffle.Domain.Interface.Entity;

namespace Raffle.Dal.Mapping
{
    public class CustomerMap: IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("Customers");
            builder.HasKey(x => x.Id);
            builder.Property("Id").ValueGeneratedOnAdd();
        }
    }
}
