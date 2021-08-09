using MyStore.Domain.DTO;
using MyStore.Domain.Models;
using MyStore.Repository.Context;

namespace MyStore.Repository
{
    public class EmployeeRepository : BaseRepository<Employee, EmployeeDTO>
    {
        public EmployeeRepository(AppDbContext context) : base(context)
        {
            
        }
    }
}