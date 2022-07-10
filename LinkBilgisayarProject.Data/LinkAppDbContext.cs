using LinkBilgisayarProject.Core.Entites;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LinkBilgisayarProject.Data
{
    public class LinkAppDbContext : DbContext
    {
        public LinkAppDbContext(DbContextOptions<LinkAppDbContext> options):base(options)
        {

        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<WeeklyReport> WeeklyReports { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<CommercialActivity> CommercialActivities { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }
    }
}
