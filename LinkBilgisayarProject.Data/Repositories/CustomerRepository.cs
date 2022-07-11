using LinkBilgisayarProject.Core.Entites;
using LinkBilgisayarProject.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkBilgisayarProject.Data.Repositories
{
    public class CustomerRepository : GenericRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(LinkAppDbContext context) : base(context)
        {
        }

        public Task<Customer> GetOneCustomerByIdWithCommercialActivityAsync(int customerId)
        {
            return _context.Customers.Include(x => x.CommercialActivities).Where(x => x.Id == customerId).SingleOrDefaultAsync();
        }
    }
}
