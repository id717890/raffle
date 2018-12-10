using Raffle.Dal.Interface.Services;
using Raffle.Domain.Interface.Entity;

namespace Raffle.Dal.Services
{
    public class GiftDrawUserRepository: Repository<GiftDrawUser>, IGiftDrawUserRepository
    {
        public GiftDrawUserRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
