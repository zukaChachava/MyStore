using MyStore.Domain.DTO;
using MyStore.Domain.Models;
using MyStore.Repository.Context;
using MyStore.Repository.Tools;
using System.Collections.Generic;

namespace MyStore.Repository
{
    public class ProductDetailsRepository : BaseRepository<ProductDetails, ProductDetailsDTO>
    {
        public ProductDetailsRepository(AppDbContext context)
            : base(context, new RepositoryPermission() { Select = 7, Add = 17, Update = 27 })
        {

        }

        public void SellProduct(IEnumerable<ProductDetails> productDetails)
        {
            foreach (ProductDetails productDetail in productDetails)
            {
                Select()
            }
        }
    }
}