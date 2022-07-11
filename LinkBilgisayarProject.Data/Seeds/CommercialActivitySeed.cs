using LinkBilgisayarProject.Core.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkBilgisayarProject.Data.Seeds
{
    public class CommercialActivitySeed : IEntityTypeConfiguration<CommercialActivity>
    {
        public void Configure(EntityTypeBuilder<CommercialActivity> builder)
        {
            builder.HasData(new CommercialActivity { Id = 1, CustomerId = 1, ServiceDescription = "Kırık Kılıç onarıldı", Price = 8800, ActivityDate = DateTime.Now.Date },
                new CommercialActivity { Id = 2, CustomerId = 2, ServiceDescription = "Baykuş satıldı", Price = 2300, ActivityDate = DateTime.Now.Date },
                 new CommercialActivity { Id = 3, CustomerId = 1, ServiceDescription = "Kılıç bilendi ", Price =10, ActivityDate = Convert.ToDateTime("10-10-2022") },
                 new CommercialActivity { Id = 4, CustomerId = 2, ServiceDescription = "Kaymak birasi satıldı", Price = 80, ActivityDate = Convert.ToDateTime("02-01-2022") });
        }
    }
}
