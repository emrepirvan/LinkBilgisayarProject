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
    public class CommercialActivityRepository : GenericRepository<CommercialActivity>, ICommercialActivityRepository
    {
        public CommercialActivityRepository(LinkAppDbContext context) : base(context)
        {

        }

        public async Task<List<CommercialActivity>> GetCommercialActivityWithCustomer()
        {

            return await _context.CommercialActivities.Include(x=> x.Customer).ToListAsync();
        }
    }
}
