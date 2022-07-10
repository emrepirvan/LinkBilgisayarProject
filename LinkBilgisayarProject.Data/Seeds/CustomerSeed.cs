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
    public class CustomerSeed : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasData(new Customer { Id = 1, Name = "Aragorn", Surname = "Arathorn", Email = "Aragorn@gmail.com", PhotoUrl = "aragorn.img", PhoneNumber = "12312312", City = "Batı Ağıl" });
            builder.HasData(new Customer { Id = 2, Name = "Harry", Surname = "Potter", Email = "expecto@gmail.com", PhotoUrl = "harry.img", PhoneNumber = "02222222", City = "Londra" });

        }
    }
}
