using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace MDotNetCore.DbService.AppDbContextModels;

public partial class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Atmaccount> Atmaccounts { get; set; }

    public virtual DbSet<Book> Books { get; set; }

    public virtual DbSet<TblLogEvent> TblLogEvents { get; set; }

    public virtual DbSet<TblPainting> TblPaintings { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.;Database=MMYDotNetCore;User ID=sa;Password=sa@123;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Atmaccount>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("ATMAccount");

            entity.Property(e => e.AccountBalance).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.AccountFirstName).HasMaxLength(50);
            entity.Property(e => e.AccountId).ValueGeneratedOnAdd();
            entity.Property(e => e.AccountLastName).HasMaxLength(50);
            entity.Property(e => e.AccountNumber).HasMaxLength(50);
        });

        modelBuilder.Entity<Book>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Book");

            entity.Property(e => e.Author).HasMaxLength(50);
            entity.Property(e => e.Category).HasMaxLength(50);
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<TblLogEvent>(entity =>
        {
            entity.ToTable("Tbl_LogEvent");

            entity.Property(e => e.TimeStamp).HasColumnType("datetime");
        });

        modelBuilder.Entity<TblPainting>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Tbl_Painting");

            entity.Property(e => e.PaintingId).ValueGeneratedOnAdd();
            entity.Property(e => e.PaintingName).HasMaxLength(50);
            entity.Property(e => e.PaintingPrice).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.PaintingType).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
