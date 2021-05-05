using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
 

#nullable disable

namespace NextBaseTest.Data.Models
{
    public partial class nextbasebackendtest20214281654Context : DbContext
    {
        public nextbasebackendtest20214281654Context()
        {
        }

        public nextbasebackendtest20214281654Context(DbContextOptions<nextbasebackendtest20214281654Context> options)
            : base(options)
        {
        }

        public virtual DbSet<TestFirmware> TestFirmwares { get; set; }
        public virtual DbSet<TestFirmwareCheck> TestFirmwareChecks { get; set; }
        public virtual DbSet<TestMonthlyVersionHistory> TestMonthlyVersionHistorys { get; set; }
  

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Name=DefaultConnection");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
             modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<TestFirmware>(entity =>
            {
                entity.ToTable("TestFirmware");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.CameraModel)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.DownloadUrl)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("DownloadURL");

                entity.Property(e => e.ReleasedOn).HasColumnType("datetime");

                entity.Property(e => e.Version).HasColumnType("decimal(5, 2)");
            });

            modelBuilder.Entity<TestFirmwareCheck>(entity =>
            {
                entity.ToTable("TestFirmwareCheck");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.CameraModel)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CameraSerial)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.CheckedOn).HasColumnType("datetime");

                entity.Property(e => e.CheckedVersion).HasColumnType("decimal(5, 2)");

                entity.Property(e => e.OfferedVersion).HasColumnType("decimal(5, 2)");
            });
            modelBuilder.Entity<TestMonthlyVersionHistory>().HasNoKey();
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
