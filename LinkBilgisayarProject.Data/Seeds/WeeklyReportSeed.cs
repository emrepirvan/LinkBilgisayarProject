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
    internal class WeeklyReportSeed : IEntityTypeConfiguration<WeeklyReport>
    {
        public void Configure(EntityTypeBuilder<WeeklyReport> builder)
        {
            builder.HasData(new WeeklyReport { Id = 1, CustomerId = 1, ReportUrl = "AragornUrlReport" },
                new WeeklyReport { Id = 2, CustomerId = 2, ReportUrl = "HarryReport" },
                new WeeklyReport { Id = 3, CustomerId = 2, ReportUrl = "HarryReport2.url" },
                new WeeklyReport { Id = 4, CustomerId = 1, ReportUrl = "Aragornreport2.url" });
        }
    }
}
