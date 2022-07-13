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
    public class AppRoleConfiguration : IEntityTypeConfiguration<RoleApp>
    {
        public void Configure(EntityTypeBuilder<RoleApp> builder)
        {
            //
        }
    }
}
