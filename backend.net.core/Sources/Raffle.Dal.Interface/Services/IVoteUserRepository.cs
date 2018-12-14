using System.Threading.Tasks;
using Raffle.Domain.Interface.Entity;

namespace Raffle.Dal.Interface.Services
{
    public interface IVoteUserRepository: IRepository<VoteUser>
    {
        Task<VoteUser> FindVoteUserById(long id);
    }
}