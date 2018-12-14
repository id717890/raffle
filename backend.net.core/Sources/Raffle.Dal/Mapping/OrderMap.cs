using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Raffle.Domain.Interface.Entity;

namespace Raffle.Dal.Mapping
{
    public class OrderMap : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Orders");
            builder.HasKey(x => x.Id);
            builder.Property(x=> x.Id).ValueGeneratedOnAdd();
            builder.Property(x=>x.OperationId).IsRequired();
            builder.Property(x=>x.NotificationType).IsRequired();
            builder.Property(x=>x.Date).IsRequired();
            builder.Property(x=>x.Amount).IsRequired();
            builder.Property(x=>x.WithdrawAmount).IsRequired();
            builder.Property(x=>x.Sender);
            builder.Property(x=>x.Codepro);
            builder.Property(x=>x.Label).IsRequired();
            builder.Property(x=>x.Sha1Hash).IsRequired();
            builder.Property(x=>x.Unaccepted).IsRequired();
        }
    }
}
