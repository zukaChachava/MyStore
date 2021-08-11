using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyStore.Domain.DTO;
using MyStore.Domain.Models;
using MyStore.Repository.Context;
using MyStore.Repository.Interfaces;

namespace MyStore.Repository
{
    public abstract class BaseRepository<TModel, TDTO> : IRepository<TModel> where TModel : BaseModel where TDTO : BaseDTO
    {
        protected readonly AppDbContext _context;
        protected readonly MapperConfiguration _mapperConfiguration;
        protected readonly Mapper _mapper;
        protected readonly DbSet<TDTO> _dbSet;
        
        protected BaseRepository(AppDbContext context)
        {
            _context = context;
            _mapperConfiguration = MapperConfiguration();
            _mapper = new Mapper(_mapperConfiguration);
            _dbSet = _context.Set<TDTO>();
        }

        public virtual TModel Get(int Id) =>  GetModel(_dbSet.Single(x => x.ID == Id));

        public virtual IEnumerable<TModel> Select() => _dbSet.Select(x => GetModel(x));

        public virtual IEnumerable<TModel> Select(Predicate<TModel> predicate) => _dbSet.Select(x => GetModel(x)).Where(x => predicate(x));

        public virtual TModel Add(TModel model)
        {
            TDTO dto = GetDTO(model);
            _dbSet.Add(dto);
            model.ID = dto.ID;
            return model;
        }

        public virtual void Update(TModel model) => _dbSet.Update(GetDTO(model));

        public virtual void Delete(TModel model) => _dbSet.Remove(GetDTO(model));

        protected TDTO GetDTO(TModel model) =>  _mapper.Map<TDTO>(model);

        protected TModel GetModel(TDTO dto) => _mapper.Map<TModel>(dto);

        protected MapperConfiguration MapperConfiguration()
        {
            return new MapperConfiguration(cfg =>
                cfg.CreateMap<TModel, TDTO>());
        }
    }
}