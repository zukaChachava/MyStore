using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Microsoft.EntityFrameworkCore.SqlServer;
using MyStore.Config;
using MyStore.Domain.DTO;

namespace MyStore.Repository.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext() : base(SqlServerDbContextOptionsExtensions.UseSqlServer(
            new DbContextOptionsBuilder(),
            new SettingsReader().GetDbSettings().ConnectionString).Options)
        {
            
        }
        
        public DbSet<EmployeeDTO> Employees { get; set; }
        public DbSet<UserDTO> Users { get; set; }
        public DbSet<CategoryDTO> Categories { get; set; }
        public DbSet<OrderDTO> Orders { get; set; }
        public DbSet<OrderDetailsDTO> OrderDetails { get; set; }
        public DbSet<ProductDTO> Products { get; set; }
        public DbSet<ProductDetailsDTO> ProductDetails { get; set; }
        public DbSet<ProviderDTO> Provider { get; set; }
        public DbSet<SellDTO> Sells { get; set; }
        public DbSet<SellDetailsDTO> SellDetails { get; set; }
        public DbSet<PermissionDTO> Permissions { get; set; }
        public DbSet<GroupDTO> Groups { get; set; }
        public DbSet<GroupPermissionsDTO> GroupPermissions { get; set; }
        public DbSet<UserGroupsDTO> UserGroups { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region DbConfiguration

            modelBuilder.Entity<UserDTO>().ToTable("Users");
            modelBuilder.Entity<SellDetailsDTO>().ToTable("SellDetails");
            modelBuilder.Entity<OrderDetailsDTO>().ToTable("OrderDetails");
            modelBuilder.Entity<ProductDetailsDTO>().ToTable("ProductDetails");

            #region UserGroups

            modelBuilder.Entity<UserGroupsDTO>()
                .HasKey(ug => new { ug.UserID, ug.GroupID });

            modelBuilder.Entity<UserGroupsDTO>()
                .HasOne(us => us.User)
                .WithMany(u => u.UserGroups)
                .HasForeignKey(us => us.UserID);
            
            modelBuilder.Entity<UserGroupsDTO>()
                .HasOne(us => us.Group)
                .WithMany(g => g.UserGroups)
                .HasForeignKey(us => us.GroupID);

            #endregion

            #region GroupPermissions

            modelBuilder.Entity<GroupPermissionsDTO>()
                .HasKey(gp => new { gp.GroupID, gp.PermissionID });

            modelBuilder.Entity<GroupPermissionsDTO>()
                .HasOne(gp => gp.Group)
                .WithMany(g => g.GroupPermissions)
                .HasForeignKey(gp => gp.GroupID);
            
            modelBuilder.Entity<GroupPermissionsDTO>()
                .HasOne(gp => gp.Permission)
                .WithMany(p => p.GroupPermissions)
                .HasForeignKey(gp => gp.PermissionID);

            #endregion
            
            #endregion
        }
    }
}