using MyStore.Domain.DTO;
using MyStore.Domain.Models;
using MyStore.Repository.Context;

namespace MyStore.Repository
{
    public class CategoryRepository : BaseRepository<Category, CategoryDTO>
    {
        public CategoryRepository(AppDbContext context) : base(context)
        {
        }

        public override void Delete(Category model)
        {
            CategoryDTO dto = _mapper.Map<CategoryDTO>(model);
            dto.IsDeleted = true;
            _dbSet.Update(dto);
        }
    }
}