using LinkBilgisayarProject.Core.Entites;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LinkBilgisayarProject.Data
{
    public class LinkAppDbContext : IdentityDbContext<UserApp,RoleApp,string>
    {
        public LinkAppDbContext(DbContextOptions<LinkAppDbContext> options):base(options)
        {

        }
        public DbSet<UserApp> AppUsers { get; set; }
        public DbSet<RoleApp> AppRoles { get; set; }
        public DbSet<UserRefreshToken>  UserRefreshTokens { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<WeeklyReport> WeeklyReports { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<CommercialActivity> CommercialActivities { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
