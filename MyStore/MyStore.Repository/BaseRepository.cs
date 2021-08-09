using System;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyStore.Domain.DTO;
using MyStore.Domain.Models;
using MyStore.Repository.Context;

namespace MyStore.Repository
{
    public abstract class BaseRepository<TModel, TDTO> where TModel : BaseModel where TDTO : BaseDTO
    {
        protected readonly AppDbContext _context;
        protected readonly MapperConfiguration _mapperConfiguration;
        protected readonly DbSet<TDTO> _dbSet;
        
        protected BaseRepository(AppDbContext context)
        {
            _context = context;
            _mapperConfiguration = MapperConfiguration();
            _dbSet = _context.Set<TDTO>();
        }

        public TModel Add(TModel model)
        {
            TDTO dto = GetDTO(model);
            _dbSet.Add(dto);
            model.ID = dto.ID;
            return model;
        }

        public void Update(TModel model) => _dbSet.Update(GetDTO(model));

        public void Delete(TModel model) => _dbSet.Remove(GetDTO(model));

        protected TDTO GetDTO(TModel model) =>  new Mapper(_mapperConfiguration).Map<TDTO>(model);

        protected MapperConfiguration MapperConfiguration()
        {
            return new MapperConfiguration(cfg =>
                cfg.CreateMap<TModel, TDTO>());
        }
    }
}