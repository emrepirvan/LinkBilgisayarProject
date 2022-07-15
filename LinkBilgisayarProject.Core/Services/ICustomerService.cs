using LinkBilgisayarProject.Core.Dtos;
using LinkBilgisayarProject.Core.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkBilgisayarProject.Core.Services
{
    public interface ICustomerService : IService<Customer>
    {
        public Task<CustomerWithCommercialAcitivityDto> GetOneCustomerByIdWithCommercialActivitiesAsync(int customerId);
        public List<Customer> GetCustomerWithSamePhonebutDifferentName();
    }
}
