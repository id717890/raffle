using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Raffle.Domain.Interface.Entity;

namespace Raffle.Domain.Interface.Services
{
    public interface IGiftDrawService
    {
        Task<IEnumerable<GiftDraw>> GetAllGifts();
    }
}
