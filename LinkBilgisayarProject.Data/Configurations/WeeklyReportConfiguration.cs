using LinkBilgisayarProject.Core.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkBilgisayarProject.Data.Configurations
{
    public class WeeklyReportConfiguration : IEntityTypeConfiguration<WeeklyReport>
    {
        public void Configure(EntityTypeBuilder<WeeklyReport> builder)
        {


        }
    }
}
