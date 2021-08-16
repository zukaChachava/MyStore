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
        public DbSet<ProviderDTO> Providers { get; set; }
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
            modelBuilder.Entity<ProductDetailsDTO>().ToTable("ProductDetails");

            #region OrderDetails

            modelBuilder.Entity<OrderDetailsDTO>()
                .HasKey(od => new { od.ID, od.ProductID });

            modelBuilder.Entity<OrderDetailsDTO>()
                .HasOne(od => od.Order)
                .WithMany(o => o.OrderDetails)
                .HasForeignKey(od => od.ID);

            modelBuilder.Entity<OrderDetailsDTO>()
                .HasOne(od => od.Product)
                .WithMany(p => p.OrderDetails)
                .HasForeignKey(od => od.ProductID);

            #endregion

            #region SellDetails

            modelBuilder.Entity<SellDetailsDTO>()
                .HasKey(sd => new { sd.ID, sd.ProductID });

            modelBuilder.Entity<SellDetailsDTO>()
                .HasOne(sd => sd.Sell)
                .WithMany(s => s.SellDetails)
                .HasForeignKey(sd => sd.ID);

            modelBuilder.Entity<SellDetailsDTO>()
                .HasOne(sd => sd.Product)
                .WithMany(p => p.SellDetails)
                .HasForeignKey(sd => sd.ProductID);

            #endregion

            #region ProductDetails

            modelBuilder.Entity<ProductDetailsDTO>()
                .HasKey(pd => new { pd.ID, pd.Valid });

            modelBuilder.Entity<ProductDetailsDTO>()
                .HasOne(pd => pd.Product)
                .WithMany(p => p.ProductDetails)
                .HasForeignKey(od => od.ID);

            #endregion

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
                .HasKey(gp => new { gp.GroupID, gp.PermissionCode });

            modelBuilder.Entity<GroupPermissionsDTO>()
                .HasOne(gp => gp.Group)
                .WithMany(g => g.GroupPermissions)
                .HasForeignKey(gp => gp.GroupID);
            
            modelBuilder.Entity<GroupPermissionsDTO>()
                .HasOne(gp => gp.Permission)
                .WithMany(p => p.GroupPermissions)
                .HasForeignKey(gp => gp.PermissionCode)
                .HasPrincipalKey(p => p.PermissionCode);

            #endregion
            
            #endregion

            #region Properties

            #region Provider

            modelBuilder.Entity<ProviderDTO>()
                .Property(p => p.IsDeleted)
                .HasDefaultValue(false);

            #endregion

            #region Employee

            modelBuilder.Entity<EmployeeDTO>()
                .Property(e => e.IsDeleted)
                .HasDefaultValue(false);

            #endregion

            #region User

            modelBuilder.Entity<UserDTO>()
                .Property(p => p.IsDeleted)
                .HasDefaultValue(false);
            
            modelBuilder.Entity<UserDTO>()
                .Property(p => p.IsActive)
                .HasDefaultValue(true);

            #endregion

            #region Category

            modelBuilder.Entity<CategoryDTO>()
                .Property(c => c.IsDeleted)
                .HasDefaultValue(false);

            #endregion

            #region Product

            modelBuilder.Entity<ProductDTO>()
                .Property(p => p.IsDeleted)
                .HasDefaultValue(false);

            #endregion

            #region Permissions

            modelBuilder.Entity<PermissionDTO>()
                .HasIndex(p => p.PermissionCode)
                .IsUnique(true)
                .IsClustered(false);

            #endregion

            #region Groups

            modelBuilder.Entity<GroupDTO>()
                .HasIndex(g => g.Name)
                .IsUnique(true)
                .IsClustered(false);

            #endregion

            #endregion
        }
    }
}