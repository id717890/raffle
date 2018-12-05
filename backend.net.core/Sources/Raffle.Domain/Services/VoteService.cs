using System.Collections.Generic;
using System.Threading.Tasks;
using Raffle.Dal.Interface.Services;
using Raffle.Domain.Interface.Entity;
using Raffle.Domain.Interface.Services;

namespace Raffle.Domain.Services
{
    public class VoteService: IVoteService
    {
        private readonly IVoteRepository _repository;

        public VoteService(IVoteRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Vote>> GetAllGifts()
        {
            return await _repository.GetAll();
        }
    }
}
