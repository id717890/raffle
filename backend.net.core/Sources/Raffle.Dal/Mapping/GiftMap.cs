using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Raffle.Domain.Interface.Entity;

namespace Raffle.Dal.Mapping
{
    public class GiftMap : IEntityTypeConfiguration<Gift>
    {
        public void Configure(EntityTypeBuilder<Gift> builder)
        {
            builder.ToTable("Gifts");
            builder.HasKey(x => x.Id);
            builder.Property("Id").ValueGeneratedOnAdd();
            builder.Property("Name").IsRequired();
            builder.Property("Image").IsRequired(false);
            builder.Property("ImageLocal").IsRequired(false);
            builder.Property("Description").IsRequired();
        }
    }
}
