using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkBilgisayarProject.Core.Dtos
{
    public class CommercialActivityWithCustomerDto : CommercialActivityDto
    {
        public CustomerDto Customer { get; set; }
    }
}
