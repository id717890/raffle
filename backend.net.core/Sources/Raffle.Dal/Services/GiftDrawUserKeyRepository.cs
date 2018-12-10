using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Raffle.Dal.Interface.Services;
using Raffle.Domain.Interface.Entity;

namespace Raffle.Dal.Services
{
    public class GiftDrawUserKeyRepository: Repository<GiftDrawUserKey>, IGiftDrawUserKeyRepository
    {
        private readonly ApplicationDbContext _db;

        public GiftDrawUserKeyRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _db = dbContext;
        }

        public async Task<long> GetCountOfKeys()
        {
            return await _db.Set<GiftDrawUserKey>().CountAsync();
        }
    }
}
