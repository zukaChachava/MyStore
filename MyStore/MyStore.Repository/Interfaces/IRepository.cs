using System;
using System.Collections.Generic;
using MyStore.Domain.Models;

namespace MyStore.Repository.Interfaces
{
    public interface IRepository<TModel> where TModel : BaseModel
    {
        TModel Get(int Id);

        IEnumerable<TModel> Select();

        IEnumerable<TModel> Select(Predicate<TModel> predicate);

        TModel Add(TModel model);

        void Update(TModel model);

        void Delete(TModel model);
    }
}