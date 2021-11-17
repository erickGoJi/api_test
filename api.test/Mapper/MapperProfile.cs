using api.test.Models.User;
using AutoMapper;
using biz.test.Entities;

namespace api.test.Mapper;

public class MapperProfile : Profile
{
    public MapperProfile()
        {
            CreateMap<User, UserDto>().ReverseMap();
        }
}