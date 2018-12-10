using System.Threading.Tasks;
using Raffle.Dal.Interface.Services;
using Raffle.Domain.Interface.Services;

namespace Raffle.Domain.Services
{
    public class GiftDrawUserKeyService: IGiftDrawUserKeyService
    {
        private readonly IGiftDrawUserKeyRepository _repository;

        public GiftDrawUserKeyService(IGiftDrawUserKeyRepository repository)
        {
            this._repository = repository;
        }

        public async Task<long> GetCountOfKeys()
        {
            return await _repository.GetCountOfKeys();
        }
    }
}
