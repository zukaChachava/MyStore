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
    }
}