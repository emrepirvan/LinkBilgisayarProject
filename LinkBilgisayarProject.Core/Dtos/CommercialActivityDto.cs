using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkBilgisayarProject.Core.Dtos
{
    public class CommercialActivityDto 
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string ServiceDescription { get; set; }
        public decimal Price { get; set; }
        public DateTime ActivityDate { get; set; }
    }
}
