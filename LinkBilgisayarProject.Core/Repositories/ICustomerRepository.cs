using LinkBilgisayarProject.Core.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkBilgisayarProject.Core.Repositories
{
    public interface ICustomerRepository :IGenericRepository<Customer>
    {
        Task<Customer> GetOneCustomerByIdWithCommercialActivityAsync(int customerId);
    }
}
