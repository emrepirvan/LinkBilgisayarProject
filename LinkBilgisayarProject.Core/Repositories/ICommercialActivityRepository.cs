using LinkBilgisayarProject.Core.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkBilgisayarProject.Core.Repositories
{
    public interface ICommercialActivityRepository : IGenericRepository<CommercialActivity>
    {
        Task<List<CommercialActivity>> GetCommercialActivityWithCustomer();
    }
}
