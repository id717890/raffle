using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Raffle.Domain.Interface.Entity;

namespace Raffle.Dal.Mapping
{
    public class GiftDrawUserMap : IEntityTypeConfiguration<GiftDrawUser>
    {
        public void Configure(EntityTypeBuilder<GiftDrawUser> builder)
        {
            builder.ToTable("GiftDrawUsers");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.HasOne<GiftDraw>(x => x.GiftDraw);
            builder.HasOne<ApplicationUser>(x => x.User);
        }
    }
}
