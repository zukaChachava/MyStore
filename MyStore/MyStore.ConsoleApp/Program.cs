using System;
using MyStore.Repository.Context;

namespace MyStore.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            using (AppDbContext context = new AppDbContext())
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
            }
        }
    }
}