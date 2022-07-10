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
    public class CommercialActivityConfiguration : IEntityTypeConfiguration<CommercialActivity>
    {
        public void Configure(EntityTypeBuilder<CommercialActivity> builder)
        {

            builder.Property(x => x.ServiceDescription).HasMaxLength(200);
            builder.Property(x => x.Price)
                .HasColumnType("decimal(18,2)");
        }
    }
}
