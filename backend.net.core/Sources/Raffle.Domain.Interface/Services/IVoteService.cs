using System.Collections.Generic;
using System.Threading.Tasks;
using Raffle.Domain.Interface.Entity;

namespace Raffle.Domain.Interface.Services
{
    public interface IVoteService
    {
        Task<IEnumerable<Vote>> GetAllGifts();
        Task<long> AddVote(VoteUser voteUser);
        Task<Vote> FindVoteById(long id);
        //Task DeleteVoteUser(Vote vote);
    }
}