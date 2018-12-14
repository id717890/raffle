using System.Threading.Tasks;
using Raffle.Domain.Interface.Entity;

namespace Raffle.Domain.Interface.Services
{
    public interface IOrderService
    {
        Task<long> CreateAsync(Order order);
    }
}