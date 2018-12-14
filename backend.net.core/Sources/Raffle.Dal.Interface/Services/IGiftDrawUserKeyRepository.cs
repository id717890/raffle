using System.Threading.Tasks;
using Raffle.Domain.Interface.Entity;

namespace Raffle.Dal.Interface.Services
{
    public interface IGiftDrawUserKeyRepository: IRepository<GiftDrawUserKey>
    {
        Task<long> GetCountOfKeys();
    }
}