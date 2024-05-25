using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using TourismGoDomain.Core.Entities;

namespace TourismGoDomain.Infrastructure.Data;

public partial class TourismGoContext : DbContext
{
    public TourismGoContext()
    {
    }

    public TourismGoContext(DbContextOptions<TourismGoContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Activities> Activities { get; set; }

    public virtual DbSet<Bookings> Bookings { get; set; }

    public virtual DbSet<Companies> Companies { get; set; }

    public virtual DbSet<Reviews> Reviews { get; set; }

    public virtual DbSet<Users> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
                => optionsBuilder.UseSqlServer("Server=BRIGITETARA9440;Database=TourismGo;Integrated Security=true;TrustServerCertificate=True");
    //=> optionsBuilder.UseSqlServer("Server=localhost;Database=TourismGo;User=sa;Pwd=12345678;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Activities>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Activiti__3214EC27C22A38E3");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CompanyId).HasColumnName("CompanyID");
            entity.Property(e => e.Duration).HasMaxLength(50);
            entity.Property(e => e.Location).HasMaxLength(100);
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.Company).WithMany(p => p.Activities)
                .HasForeignKey(d => d.CompanyId)
                .HasConstraintName("FK__Activitie__Compa__3B75D760");
        });

        modelBuilder.Entity<Bookings>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Bookings__3214EC276F26B86A");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.ActivityId).HasColumnName("ActivityID");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.Activity).WithMany(p => p.Bookings)
                .HasForeignKey(d => d.ActivityId)
                .HasConstraintName("FK__Bookings__Activi__3F466844");

            entity.HasOne(d => d.User).WithMany(p => p.Bookings)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Bookings__UserID__3E52440B");
        });

        modelBuilder.Entity<Companies>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Companie__3214EC2706F5F197");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Address).HasMaxLength(200);
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.Phone).HasMaxLength(20);
        });

        modelBuilder.Entity<Reviews>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Reviews__3214EC27C6180CB4");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.ActivityId).HasColumnName("ActivityID");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.Activity).WithMany(p => p.Reviews)
                .HasForeignKey(d => d.ActivityId)
                .HasConstraintName("FK__Reviews__Activit__4316F928");

            entity.HasOne(d => d.User).WithMany(p => p.Reviews)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Reviews__UserID__4222D4EF");
        });

        modelBuilder.Entity<Users>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Users__3214EC276DBCA855");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.Password).HasMaxLength(100);
            entity.Property(e => e.Role).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
