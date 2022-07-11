using AutoMapper;
using LinkBilgisayarProject.Core.Dtos;
using LinkBilgisayarProject.Core.Entites;
using LinkBilgisayarProject.Core.Repositories;
using LinkBilgisayarProject.Core.Services;
using LinkBilgisayarProject.Core.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkBilgisayarProject.Service.Services
{
    public class CustomerService : Service<Customer>, ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;
        public CustomerService(IGenericRepository<Customer> repository, IUnitOfWork unitOfWork, ICustomerRepository customerRepository = null, IMapper mapper = null) : base(repository, unitOfWork)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }
        public async Task<CustomerWithCommercialAcitivityDto> GetOneCustomerByIdWithCommercialActivitiesAsync(int customerId)
        {
            var customer = await _customerRepository.GetOneCustomerByIdWithCommercialActivityAsync(customerId);
            var customerDto = _mapper.Map<CustomerWithCommercialAcitivityDto>(customer);

            return customerDto;
        }
    }
}
