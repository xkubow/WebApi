using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebApi
{
    public partial class TestDbContext : DbContext
    {
        public TestDbContext()
        {
        }

        public TestDbContext(DbContextOptions<TestDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Test> Test { get; set; }
        public virtual DbSet<Vozidlo> Vozidlo { get; set; }
        public virtual DbSet<Vyrobek> Vyrobek { get; set; }
        public virtual DbSet<Zakaznik> Zakaznik { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseNpgsql("Host=10.219.61.90;Database=postgres;Username=postgres;Password=Post2020SQL");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasPostgresExtension("adminpack");

            modelBuilder.Entity<Test>(entity =>
            {
                entity.ToTable("Test", "DMSTEST");

                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<Vozidlo>(entity =>
            {
                entity.ToTable("VOZIDLO", "DMSTEST");

                entity.Property(e => e.VozidloId)
                    .HasColumnName("VOZIDLO_ID")
                    .HasIdentityOptions(null, null, null, 10000000L, null, null)
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.Rzv)
                    .IsRequired()
                    .HasColumnName("RZV");

                entity.Property(e => e.VyrobekOzn).HasColumnName("VYROBEK_OZN");

                entity.Property(e => e.ZakaznikId).HasColumnName("ZAKAZNIK_ID");

                entity.HasOne(d => d.VyrobekOznNavigation)
                    .WithMany(p => p.Vozidlo)
                    .HasForeignKey(d => d.VyrobekOzn)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("VOZIDLO_VYROBEK_OZN_fkey");

                entity.HasOne(d => d.Zakaznik)
                    .WithMany(p => p.Vozidlo)
                    .HasForeignKey(d => d.ZakaznikId)
                    .HasConstraintName("VOZIDLO_ZAKAZNIK_ID_fkey");
            });

            modelBuilder.Entity<Vyrobek>(entity =>
            {
                entity.HasKey(e => e.VyrobekOzn)
                    .HasName("VYROBEK_pkey");

                entity.ToTable("VYROBEK", "DMSTEST");

                entity.Property(e => e.VyrobekOzn)
                    .HasColumnName("VYROBEK_OZN")
                    .ValueGeneratedNever();

                entity.Property(e => e.Text)
                    .IsRequired()
                    .HasColumnName("TEXT");
            });

            modelBuilder.Entity<Zakaznik>(entity =>
            {
                entity.ToTable("ZAKAZNIK", "DMSTEST");

                entity.Property(e => e.ZakaznikId)
                    .HasColumnName("ZAKAZNIK_ID")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.Jmeno)
                    .IsRequired()
                    .HasColumnName("JMENO");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
