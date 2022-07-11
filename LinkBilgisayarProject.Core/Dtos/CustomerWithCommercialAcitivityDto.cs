using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkBilgisayarProject.Core.Dtos
{
    public class CustomerWithCommercialAcitivityDto :CustomerDto
    {
        public List<CommercialActivityDto> commercialActivities  { get; set; }
    }
}
