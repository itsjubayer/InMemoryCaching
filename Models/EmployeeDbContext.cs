using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace InMemoryCaching.Models;

public partial class EmployeeDbContext : DbContext
{
    
    public EmployeeDbContext(DbContextOptions<EmployeeDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Asset> Assets { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<FacilitySite> FacilitySites { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=DBConnectionString");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Asset>(entity =>
        {
            entity.HasKey(e => e.AssetId).HasName("PK_dbo.Assets");

            entity.HasIndex(e => e.FacilitySiteId, "IX_FacilitySiteID");

            entity.Property(e => e.AssetId)
                .ValueGeneratedNever()
                .HasColumnName("AssetID");
            entity.Property(e => e.AstId).HasColumnName("AstID");
            entity.Property(e => e.FacilitySiteId).HasColumnName("FacilitySiteID");
            entity.Property(e => e.Merno).HasColumnName("MERNo");
            entity.Property(e => e.Pmguide).HasColumnName("PMGuide");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Employee");

            entity.Property(e => e.Action)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Country)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.EmployeeId)
                .ValueGeneratedOnAdd()
                .HasColumnName("EmployeeID");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.State)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<FacilitySite>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.FacilitySiteId).HasColumnName("FacilitySiteID");
            entity.Property(e => e.ModifiedAt).HasColumnType("datetime");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
