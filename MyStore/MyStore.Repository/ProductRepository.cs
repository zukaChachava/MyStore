using MyStore.Domain.DTO;
using MyStore.Domain.Models;
using MyStore.Repository.Context;
using MyStore.Repository.Tools;
using MyStore.Repository.Exceptions;
using System.Collections.Generic;
using System;
using MyStore.Repository.DomainMapper;

namespace MyStore.Repository
{
    public class ProductRepository : BaseRepository<Product, ProductDTO>
    {
        protected Lazy<CategoryRepository> _categoryRepository;

        public ProductRepository(AppDbContext context) 
            : base(context, new RepositoryPermission() { Select = 7 })
        {
            _categoryRepository = new Lazy<CategoryRepository>(new CategoryRepository(_context));
        }

        public IEnumerable<Category> GetCategories(User user)
        {
            return _categoryRepository.Value.Select(user);
        }

        public override void Delete(User user, Product model)
        {
            if (!HasPermision(user, _repositoryPermission.Delete))
                throw new NotHavePermission("Do not have Delete Permission");

            ProductDTO dto = _mapper.Map<ProductDTO>(model);
            dto.IsDeleted = true;
            _dbSet.Update(dto);
        }
    }
}