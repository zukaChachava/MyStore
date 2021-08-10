using Microsoft.EntityFrameworkCore;
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region DbConfiguration

            modelBuilder.Entity<UserDTO>().ToTable("Users");
            modelBuilder.Entity<SellDetailsDTO>().ToTable("SellDetails");
            modelBuilder.Entity<OrderDetailsDTO>().ToTable("OrderDetails");
            modelBuilder.Entity<ProductDetailsDTO>().ToTable("ProductDetails");

            #endregion
        }
    }
}