using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Eatech.FleetManager.Web.Models
{
    public partial class FleetManagerContext : DbContext
    {
        public virtual DbSet<Cars> Cars { get; set; }

        public FleetManagerContext(DbContextOptions<FleetManagerContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cars>(entity =>
            {
                entity.ToTable("cars");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Make)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Model)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Registration)
                    .IsRequired()
                    .HasMaxLength(50);
            });
        }
    }
}
