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

        public override void Delete(Product model)
        {
            ProductDTO dto = _mapper.Map<ProductDTO>(model);
            dto.IsDeleted = true;
            _dbSet.Update(dto);
        }
    }
}