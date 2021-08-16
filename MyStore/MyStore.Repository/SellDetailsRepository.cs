using MyStore.Domain.DTO;
using MyStore.Domain.Models;
using MyStore.Repository.Context;
using MyStore.Repository.Tools;
using System;
using System.Collections.Generic;

namespace MyStore.Repository
{
    public class SellDetailsRepository : BaseRepository<SellDetails, SellDetailsDTO>
    {
        protected Lazy<ProductRepository> _productRepository;
        protected Lazy<ProductDetailsRepository> _productDetailsRepository;

        public SellDetailsRepository(AppDbContext context) 
            : base(context, new RepositoryPermission() { Select = 9 })
        {
            _productRepository = new Lazy<ProductRepository>(new ProductRepository(_context));
            _productDetailsRepository = new Lazy<ProductDetailsRepository>(new ProductDetailsRepository(_context));
        }

        public IEnumerable<Product> GetProducts(User user)
        {
            return _productRepository.Value.Select(user);
        }

        public IEnumerable<ProductDetails> GetProductDetails(User user, Product product)
        {
            return _productDetailsRepository.Value.Select(user, pd => pd.Product == product);
        }
    }
}