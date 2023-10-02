using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BusinessLogic;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Windows.Controls;

namespace EditingUsersDAL
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext()
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Module> Modules { get; set; }
        public DbSet<Permission> Permissions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Server=localhost;Port=5432;Username=postgres;Password=123098;Database=RegisteredUsersDB");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany(p => p.Permissions)
                .WithOne(u => u.User)
                .HasForeignKey(s => s.UserId);

            //modelBuilder.Ignore<Module>();
            //modelBuilder.Entity<Permission>().OwnsOne(p => p.Module);
        }
    }
}
