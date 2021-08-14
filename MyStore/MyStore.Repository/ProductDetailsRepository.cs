using MyStore.Domain.DTO;
using MyStore.Domain.Models;
using MyStore.Repository.Context;
using MyStore.Repository.Tools;

namespace MyStore.Repository
{
    public class ProductDetailsRepository : BaseRepository<ProductDetails, ProductDetailsDTO>
    {
        public ProductDetailsRepository(AppDbContext context) 
            : base(context, new RepositoryPermission() { Select = 100})
        {
            
        }
    }
}