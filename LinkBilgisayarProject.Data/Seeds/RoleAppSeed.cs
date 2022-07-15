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
    public class RoleAppSeed : IEntityTypeConfiguration<RoleApp>
    {
        public void Configure(EntityTypeBuilder<RoleApp> builder)
        {
            //builder.HasData(new RoleApp { Id = "AdminId", Name = "admin" , NormalizedName ="ADMIN" }, 
            //    new RoleApp { Id = "EditorId", Name = "editor", NormalizedName ="EDITOR" });
        }
    }
}