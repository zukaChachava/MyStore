using MyStore.Domain.DTO;
using MyStore.Domain.Models;
using MyStore.Repository.Context;
using MyStore.Repository.DomainMapper;
using MyStore.Repository.Tools;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyStore.Repository
{
    public class OrderDetailsRepository : BaseRepository<OrderDetails, OrderDetailsDTO>
    {
        protected Lazy<ProductRepository> _productRepository;
        protected Lazy<OrderRepository> _orderRepository;

        public OrderDetailsRepository(AppDbContext context) 
            : base(context, new RepositoryPermission() { Select = 6 })
        {
            _productRepository = new Lazy<ProductRepository>(new ProductRepository(_context));
            _orderRepository = new Lazy<OrderRepository>(new OrderRepository(_context));
        }

        public decimal GetProductPrice(Product product)
        {
            return _productRepository.Value.Get(product).Price;
        }
        public IEnumerable<Product> GetProducts(User user)
        {
            return _productRepository.Value.Select(user);
        }
    }
}