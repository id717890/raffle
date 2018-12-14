using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Raffle.Dal.Interface.Services;
using Raffle.Domain.Interface.Entity;
using Raffle.Domain.Interface.Services;

namespace Raffle.Domain.Services
{
    public class VoteService: IVoteService
    {
        private readonly IVoteRepository _voteRepository;
        private readonly IVoteUserRepository _voteUserRepository;


        public VoteService(IVoteRepository voteRepository, IVoteUserRepository voteUserRepository)
        {
            _voteRepository = voteRepository;
            _voteUserRepository = voteUserRepository;
        }

        public async Task<IEnumerable<Vote>> GetAllGifts()
        {
            return await _voteRepository.GetAll();
        }

        public async Task<long> AddVote(VoteUser voteUser)
        {
            return await _voteUserRepository.Create(voteUser);
        }

        public async Task<Vote> FindVoteById(long id)
        {
            return await _voteRepository.GetById(id);
        }
    }
}
