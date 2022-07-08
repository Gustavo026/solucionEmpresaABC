using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace solucionEmpresaABC.Models
{
    public partial class dbTestContext : DbContext
    {
        public dbTestContext()
        {
        }

        public dbTestContext(DbContextOptions<dbTestContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Area> Areas { get; set; } = null!;
        public virtual DbSet<Employee> Employees { get; set; } = null!;
        public virtual DbSet<Subarea> Subareas { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-455A4T5\\SQLEXPRESS; Database=dbTest; Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Area>(entity =>
            {
                entity.HasKey(e => e.IdArea);

                entity.ToTable("area");

                entity.Property(e => e.IdArea).HasColumnName("idArea");

                entity.Property(e => e.Area1)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("area");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("employee");

                entity.Property(e => e.ApellidoMaterno)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("apellidoMaterno");

                entity.Property(e => e.ApellidoPaterno)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("apellidoPaterno");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.IdArea).HasColumnName("idArea");

                entity.Property(e => e.IdEmpleado)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("idEmpleado");

                entity.Property(e => e.IdSubarea).HasColumnName("idSubarea");

                entity.Property(e => e.NombreEmpleado)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("nombreEmpleado");

                entity.HasOne(d => d.IdAreaNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdArea)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_employee_area");
            });

            modelBuilder.Entity<Subarea>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("subarea");

                entity.Property(e => e.IdArea).HasColumnName("idArea");

                entity.Property(e => e.IdSubarea)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("idSubarea");

                entity.Property(e => e.SubArea1)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("subArea");

                entity.HasOne(d => d.IdAreaNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdArea)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_subarea_area");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
