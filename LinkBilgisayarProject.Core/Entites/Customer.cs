using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkBilgisayarProject.Core.Entites
{
    public class Customer 
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Email { get; set; }
        public string? PhotoUrl { get; set; }
        public string? PhoneNumber { get; set; }
        public string? City { get; set; }
        public ICollection<CommercialActivity> CommercialActivities { get; set; }
        public ICollection<WeeklyReport> WeeklyReports { get; set; }

    }
}
