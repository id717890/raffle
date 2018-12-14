using System.Threading.Tasks;

namespace Raffle.Domain.Interface.Services
{
    public interface IGiftDrawUserKeyService
    {
        Task<long> GetCountOfKeys();
    }
}