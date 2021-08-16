using MyStore.Domain.DTO;
using MyStore.Domain.Models;
using MyStore.Repository.Context;
using MyStore.Repository.Tools;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyStore.Repository
{
    public class OrderDetailsRepository : BaseRepository<OrderDetails, OrderDetailsDTO>
    {
        protected Lazy<ProductRepository> _productRepository;

        public OrderDetailsRepository(AppDbContext context) 
            : base(context, new RepositoryPermission() { Select = 6 })
        {
            _productRepository = new Lazy<ProductRepository>(new ProductRepository(_context));
        }

        public IEnumerable<Product> GetProducts(User user)
        {
            return _productRepository.Value.Select(user);
        }
    }
}