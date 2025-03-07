using Manage_lead.Models;
using Microsoft.EntityFrameworkCore;

namespace Manage_lead.Data
{
    public class MyDbContext(DbContextOptions<MyDbContext> options) : DbContext(options)
    {
        public DbSet<LeadEntity> Leads { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<LeadEntity>().ToTable("Leads");
        }
    }
}
