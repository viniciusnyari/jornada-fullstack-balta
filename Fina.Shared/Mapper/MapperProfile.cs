using AutoMapper;
using Fina.Shared.Models;
using Fina.Shared.Requests.Categories;

namespace Fina.Shared.Mapper;

public class MapperProfile : Profile
{
    public MapperProfile()
    {
        CreateMap<UpdateCategoryRequest, Category>().ReverseMap();
    }
}