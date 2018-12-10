using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Raffle.Domain.Interface.Entity;

namespace Raffle.Dal.Mapping
{
    class VoteUserMap : IEntityTypeConfiguration<VoteUser>
    {
        public void Configure(EntityTypeBuilder<VoteUser> builder)
        {
            builder.ToTable("VoteUsers");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Value).IsRequired();
            builder.HasOne<ApplicationUser>(x => x.User);
            builder.HasOne<Vote>(x => x.Vote);
        }
    }
}
