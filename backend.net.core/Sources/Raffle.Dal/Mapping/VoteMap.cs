using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Raffle.Domain.Interface.Entity;

namespace Raffle.Dal.Mapping
{
    public class VoteMap : IEntityTypeConfiguration<Vote>
    {
        public void Configure(EntityTypeBuilder<Vote> builder)
        {
            builder.ToTable("Votes");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Price).IsRequired();
            builder.Property(x => x.VotesAgree).IsRequired();
            builder.Property(x => x.VotesDisagree).IsRequired();
            builder.HasOne<Gift>(x => x.Gift);
            //builder.HasMany<VoteUser>(x => x.VoteUsers).WithOne();
        }
    }
}
