using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;

namespace MyStore.Repository.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext() : base(SqlServerDbContextOptionsExtensions.UseSqlServer(
            new DbContextOptionsBuilder(),
            @"server=localhost; database=MyAutoCenter; uid=sa; pwd=Password123;").Options)
        {
            
        }
    }
}