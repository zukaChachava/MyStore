using MyStore.Domain.DTO;
using MyStore.Domain.Models;
using MyStore.Repository.Context;
using MyStore.Repository.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStore.Repository
{
    internal class GroupRepository : BaseRepository<Groups , GroupsDTO>
    {
        public GroupRepository(AppDbContext context) : base(context, new RepositoryPermission() { Select = 41 })
        {

        }
    }
}
