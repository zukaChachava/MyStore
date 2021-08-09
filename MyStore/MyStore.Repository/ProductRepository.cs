using MyStore.Domain.DTO;
using MyStore.Domain.Models;
using MyStore.Repository.Context;

namespace MyStore.Repository
{
    public class ProductRepository : BaseRepository<Product, ProductDTO>
    {
        public ProductRepository(AppDbContext context) : base(context)
        {
            
        }
    }
}