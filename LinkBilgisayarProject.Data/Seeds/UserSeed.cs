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
    public class UserSeed : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasData(new User { Id = 1, Username = "Gandalf", Password = "12345", IsAdmin = true },
                        new User { Id = 2, Username = "Frodo", Password = "987654", IsAdmin = false },
                        new User { Id = 3, Username = "Gimli", Password = "00000", IsAdmin = true });
        }
    }
}
