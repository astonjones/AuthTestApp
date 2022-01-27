using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuthTestApp.Models;
using Microsoft.EntityFrameworkCore;

namespace AuthTestApp.Data
{
    public partial class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public virtual DbSet<Hardware> Hardware { get; set; }

        //USE WHEN DB connection is set up.
        //public virtual DbSet<Lead> Lead { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.;Database=TicketTest;Trusted_Connection=True;MultipleActiveResultSets=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Hardware>(entity =>
            {
                entity.HasKey(e => e.SN);

                entity.ToTable("Hardware");

                entity.Property(e => e.SN).HasColumnName("SN");

                entity.Property(e => e.In_Use)
                    .IsRequired()
                    .HasColumnName("In_Use");

                entity.Property(e => e.MAC_Address).HasColumnName("MAC_Address");

                entity.Property(e => e.Model_Number).HasColumnName("Model_Number");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

