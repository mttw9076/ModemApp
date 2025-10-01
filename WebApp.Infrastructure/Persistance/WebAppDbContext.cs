using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApp.Domain.Entities;

namespace WebApp.Infrastructure.Persistance
{
    public class WebAppDbContext : IdentityDbContext
    {
        public DbSet<Domain.Entities.Modem> Modems { get; set; }
        public DbSet<Domain.Entities.DSL> DSLs { get; set; }
        public DbSet<SIMCard> SIMCards { get; set; } = default!;

        public DbSet<Domain.Entities.Shops> Shops { get; set; }
        public WebAppDbContext(DbContextOptions<WebAppDbContext> options) : base(options) 
        { 

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<SIMCard>()
                .HasOne(s => s.Modem)
                .WithOne(m => m.SIMCard)
                .HasForeignKey<SIMCard>(s => s.ModemId)
                .OnDelete(DeleteBehavior.SetNull);
            modelBuilder.Entity<Modem>()
                .HasOne(m => m.SIMCard)
                .WithOne(s => s.Modem)
                .HasForeignKey<SIMCard>(s => s.ModemId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.SetNull);
            modelBuilder.Entity<Modem>()
                .Property(m => m.ModemId)
                .ValueGeneratedOnAdd();

        }

    }
}
