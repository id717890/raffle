using System;
using System.Threading.Tasks;
using Raffle.Domain.Interface.Entity;

namespace Raffle.Domain.Interface.Services
{
    public interface ICustomerService
    {
        Task<long> Create(Customer customer);
    }
}