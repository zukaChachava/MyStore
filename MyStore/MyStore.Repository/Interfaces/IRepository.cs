using System;
using System.Collections.Generic;
using MyStore.Domain.Models;

namespace MyStore.Repository.Interfaces
{
    public interface IRepository<TModel> where TModel : BaseModel
    {
        TModel Get(int Id);

        IEnumerable<TModel> Select(User user);

        IEnumerable<TModel> Select(User user, Predicate<TModel> predicate);

        TModel Add(User user, TModel model);

        void Update(User user, TModel model);

        void Delete(User user, TModel model);
    }
}