using Raffle.Dal.Interface.Services;
using Raffle.Domain.Interface.Entity;

namespace Raffle.Dal.Services
{
    public class OrderRepository: Repository<Order>, IOrderRepository
    {
        public OrderRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
