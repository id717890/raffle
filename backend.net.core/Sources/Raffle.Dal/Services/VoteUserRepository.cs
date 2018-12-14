using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Raffle.Dal.Interface.Services;
using Raffle.Domain.Interface.Entity;

namespace Raffle.Dal.Services
{
    public class VoteUserRepository: Repository<VoteUser>, IVoteUserRepository
    {
        private readonly ApplicationDbContext _db;

        public VoteUserRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _db = dbContext;
        }

        public async Task<VoteUser> FindVoteUserById(long id)
        {
            return await _db.Set<VoteUser>().AsNoTracking().SingleOrDefaultAsync(x=>x.Id == id);
        }
    }
}
