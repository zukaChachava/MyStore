using MyStore.Domain.DTO;
using MyStore.Domain.Models;
using MyStore.Repository.Context;
using MyStore.Repository.Tools;
using System.Collections.Generic;
using System.Linq;
using System;

namespace MyStore.Repository
{
    public class ProductDetailsRepository : BaseRepository<ProductDetails, ProductDetailsDTO>
    {
        public ProductDetailsRepository(AppDbContext context)
            : base(context, new RepositoryPermission() { Select = 7, Add = 17, Update = 27 })
        {

        }

        public void SellProducts(IEnumerable<ProductDetails> productDetails)
        {
            foreach (ProductDetails productDetail in productDetails)
            {
                var availableProducts = _dbSet.Where(pd => pd.ID == productDetail.ID)
                    .Where(pd => pd.Valid >= DateTime.Now)
                    .OrderBy(pd => pd.Valid);
                foreach (ProductDetailsDTO availableProduct in availableProducts)
                {
                    if(availableProduct.Quantity > productDetail.Quantity)
                    {
                        availableProduct.Quantity -= productDetail.Quantity ?? 0;
                        break;
                    }
                    productDetail.Quantity -= availableProduct.Quantity;
                    availableProduct.Quantity = 0;
                }
            }
        }
    }
}