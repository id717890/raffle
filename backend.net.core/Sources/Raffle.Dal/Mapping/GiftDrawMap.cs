using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Raffle.Domain.Interface.Entity;

namespace Raffle.Dal.Mapping
{
    public class GiftDrawMap : IEntityTypeConfiguration<GiftDraw>
    {
        public void Configure(EntityTypeBuilder<GiftDraw> builder)
        {
            builder.ToTable("GiftDraws");
            builder.HasKey(x => x.Id);
            builder.Property(x=>x.Id).ValueGeneratedOnAdd();
            builder.Property(x=>x.Info).IsRequired();
            builder.Property(x=>x.Price).IsRequired();
            builder.Property(x=>x.PriceKey).IsRequired();
            builder.Property(x => x.Reached).IsRequired();
            builder.HasOne<Gift>(x => x.Gift).WithMany(y => y.GiftDraws).IsRequired();
        }
    }
}
