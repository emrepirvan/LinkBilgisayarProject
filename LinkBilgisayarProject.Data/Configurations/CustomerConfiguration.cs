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
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {

            builder.Property(x => x.Name)
                .HasMaxLength(50);
            builder.Property(x => x.Surname)
                .HasMaxLength(50);
            builder.Property(x => x.City)
                .HasMaxLength(80);




            builder.Property(x => x.Email).HasMaxLength(100);

            builder.Property(x => x.PhoneNumber)
                .HasMaxLength(12);


            builder.HasMany(x => x.CommercialActivities).WithOne(x => x.Customer).HasForeignKey(x => x.CustomerId);
            builder.HasMany(x => x.WeeklyReports).WithOne(x => x.Customer).HasForeignKey(x => x.CustomerId);
        }
    }
}
