using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Raffle.Dal.Interface.Services;
using Raffle.Domain.Interface.Entity;

namespace Raffle.Dal.Services
{
    public class VoteRepository: Repository<Vote>, IVoteRepository
    {
        private readonly ApplicationDbContext _db;

        public VoteRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _db = dbContext;
        }

        public override async Task<List<Vote>> GetAll()
        {
            return await _db.Set<Vote>().Include(x => x.Gift).Include(x=>x.VoteUsers).ToListAsync();
        }
    }
}
