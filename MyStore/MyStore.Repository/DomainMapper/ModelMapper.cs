using AutoMapper;
using MyStore.Domain.DTO;
using MyStore.Domain.Models;
using System;
using System.Collections.Generic;

namespace MyStore.Repository.DomainMapper
{
    internal static class ModelMapper
    {
        private static IDictionary<Type, IMapper> _mappers;

        static ModelMapper()
        {
            _mappers = new Dictionary<Type, IMapper>();
            UserMapper();
        }

        public static IMapper GetMapper<TModel, TDTO>() where TModel : BaseModel where TDTO : BaseDTO
        {
            Type type = typeof(TDTO);
            if (!_mappers.Keys.Contains(type))
                _mappers.Add(type, new MapperConfiguration(cfg =>
                cfg.CreateMap<TModel, TDTO>().ReverseMap()).CreateMapper());

            return _mappers[type];
        }

        private static void UserMapper()
        {
            _mappers.Add(typeof(UserDTO), new MapperConfiguration(cfg =>
                cfg.CreateMap<User, UserDTO>()
                .ForSourceMember(u => u.Password, ud => ud.DoNotValidate())
                .ReverseMap()).CreateMapper());
        }
    }
}
