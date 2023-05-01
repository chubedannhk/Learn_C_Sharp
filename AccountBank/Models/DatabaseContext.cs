using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace AccountBank.Models;

public partial class DatabaseContext : DbContext
{
    public DatabaseContext()
    {
    }

    public DatabaseContext(DbContextOptions<DatabaseContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Account> Accounts { get; set; }

    public virtual DbSet<TransactionDetail> TransactionDetails { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("Server=NGUYENHOANGKHAI\\SQLEXPRESS;Database=AccountBank;user id=sa;password=Nhk2503##;trusted_connection=true;encrypt=false");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Account>(entity =>
        {
            entity.HasKey(e => e.AccId).HasName("PK__Account__91CBC398FB523958");

            entity.ToTable("Account");

            entity.Property(e => e.AccId).HasColumnName("AccID");
            entity.Property(e => e.Balance).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.Email)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.Fullname)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.Phone)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.Username)
                .HasMaxLength(250)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TransactionDetail>(entity =>
        {
            entity.HasKey(e => e.TransId).HasName("PK__Transact__9E5DDB3C915140BA");

            entity.Property(e => e.AccId).HasColumnName("AccID");
            entity.Property(e => e.DateOfTrans)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("date");
            entity.Property(e => e.TransMonry).HasColumnType("decimal(18, 0)");

            entity.HasOne(d => d.Acc).WithMany(p => p.TransactionDetails)
                .HasForeignKey(d => d.AccId)
                .HasConstraintName("fk_Trans_Acc");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
