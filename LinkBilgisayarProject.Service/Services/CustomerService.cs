using AutoMapper;
using LinkBilgisayarProject.Core.Dtos;
using LinkBilgisayarProject.Core.Entites;
using LinkBilgisayarProject.Core.Repositories;
using LinkBilgisayarProject.Core.Services;
using LinkBilgisayarProject.Core.UnitOfWorks;
using LinkBilgisayarProject.Service.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkBilgisayarProject.Service.Services
{
    public class CustomerService : Service<Customer>, ICustomerService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;
        public CustomerService(IGenericRepository<Customer> repository, IUnitOfWork unitOfWork, ICustomerRepository customerRepository = null, IMapper mapper = null) : base(repository, unitOfWork)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<CustomerWithCommercialAcitivityDto> GetOneCustomerByIdWithCommercialActivitiesAsync(int customerId)
        {
            var customer = await _customerRepository.GetOneCustomerByIdWithCommercialActivityAsync(customerId);
            if (customer == null)
            {
                throw new CustomException($"{typeof(Customer).Name}({customerId}) not found");
            }
            var customerDto = _mapper.Map<CustomerWithCommercialAcitivityDto>(customer);

            return customerDto;
        }
        public List<Customer> GetCustomerWithSamePhonebutDifferentName()
        {
            var customers =  _customerRepository.GetAll().AsQueryable();
            var nums = customers.Select(x => x.PhoneNumber).ToList();


            var SameNumPerson = new List<Customer>();
            var DifNames = new List<Customer>();

            foreach (var customer in customers)
            {
                int counter = 0;
                for (int i = 0; i < nums.Count(); i++)
                {
                    if (customer.PhoneNumber == nums[i])
                    {
                        counter++;
                    }
                }
                if (counter > 1)
                {
                    if (!(SameNumPerson.Select(x => x.Name).Contains(customer.Name)))
                    {
                        SameNumPerson.Add(customer);
                    }  
                }
            }
            return  SameNumPerson;
        }

    }
}