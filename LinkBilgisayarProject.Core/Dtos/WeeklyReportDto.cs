using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkBilgisayarProject.Core.Dtos
{
    public class WeeklyReportDto
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string ReportUrl { get; set; }
    }
}
