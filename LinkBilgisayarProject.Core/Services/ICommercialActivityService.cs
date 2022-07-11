using LinkBilgisayarProject.Core.Dtos;
using LinkBilgisayarProject.Core.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkBilgisayarProject.Core.Services
{
    public interface ICommercialActivityService :IService<CommercialActivity>
    {
        public Task<List<CommercialActivityWithCustomerDto>> GetCommercialActivitiesWithCustomer();
    }
}
