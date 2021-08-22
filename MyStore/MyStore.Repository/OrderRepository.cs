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
    public class OrderRepository : BaseRepository<Order, OrderDTO>
    {
        protected Lazy<ProviderRepository> _providerRepository;
        protected Lazy<UserRepository> _userRepository;

        public OrderRepository(AppDbContext context) 
            : base(context, new RepositoryPermission() { Select = 5 })
        {
            _providerRepository = new Lazy<ProviderRepository>(new ProviderRepository(_context));
            _userRepository = new Lazy<UserRepository>(new UserRepository(_context));
        }

        public IEnumerable<Provider> GetProviders(User user)
        {
            return _providerRepository.Value.Select(user);
        }
    }
}