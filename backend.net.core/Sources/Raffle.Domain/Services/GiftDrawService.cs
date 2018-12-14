using System.Collections.Generic;
using System.Threading.Tasks;
using Raffle.Dal.Interface.Services;
using Raffle.Domain.Interface.Entity;
using Raffle.Domain.Interface.Services;

namespace Raffle.Domain.Services
{
    public class GiftDrawService: IGiftDrawService
    {
        private readonly IGiftDrawRepository _repository;

        public GiftDrawService(IGiftDrawRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<GiftDraw>> GetAllGifts()
        {
            return await _repository.GetAll();
        }

        public async Task<long> GetCountOfGifts()
        {
            return await _repository.GetCountOfGifts();
        }
    }
}
