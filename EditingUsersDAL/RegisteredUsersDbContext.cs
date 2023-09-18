using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace EditingUsersDAL;

public partial class RegisteredUsersDbContext : DbContext
{
    public RegisteredUsersDbContext()
    {
    }

    public RegisteredUsersDbContext(DbContextOptions<RegisteredUsersDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Module> Modules { get; set; }

    public virtual DbSet<Permission> Permissions { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Server=localhost;Port=5432;Username=postgres;Password=123098;Database=RegisteredUsersDB");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Module>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
        });

        modelBuilder.Entity<Permission>(entity =>
        {
            entity.HasIndex(e => e.ModuleId, "IX_Permissions_ModuleId");

            entity.HasIndex(e => e.UserId, "IX_Permissions_UserId");

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.Module).WithMany(p => p.Permissions).HasForeignKey(d => d.ModuleId);

            entity.HasOne(d => d.User).WithMany(p => p.Permissions).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
