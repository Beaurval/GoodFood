using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace goodfood_provider.Entities
{
    public class ProviderContext : DbContext
    {
        public ProviderContext(DbContextOptions<ProviderContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Provider>().Property(p => p.ProviderImage).HasColumnType("image");
        }
        public DbSet<Provider> Providers { get; set; } = null!;
    }
}
