using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Raffle.Dal.Interface.Services;
using Raffle.Domain.Interface.Entity;
using Raffle.Domain.Interface.Services;

namespace Raffle.Domain.Services
{
    public class CustomerService: ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository repository)
        {
            _customerRepository = repository;
        }

        public Task<long> Create(Customer customer)
        {
            return _customerRepository.Create(customer);
        }
    }
}
