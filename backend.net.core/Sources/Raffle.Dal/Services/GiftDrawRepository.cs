using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Raffle.Dal.Interface.Services;
using Raffle.Domain.Interface.Entity;

namespace Raffle.Dal.Services
{
    public class GiftDrawRepository: Repository<GiftDraw>, IGiftDrawRepository
    {
        private readonly ApplicationDbContext _db;

        public GiftDrawRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _db = dbContext;
        }

        public override async Task<List<GiftDraw>> GetAll()
        {
            return await _db.Set<GiftDraw>().Include(x => x.Gift).ToListAsync();
        }

        public async Task<long> GetCountOfGifts()
        {
            return await _db.Set<GiftDraw>().CountAsync(x => x.IsDeleted == false);
        }
    }
}
