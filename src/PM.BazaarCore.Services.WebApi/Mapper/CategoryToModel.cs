using AutoMapper;
using PM.BazaarCore.Domain.Entities;
using PM.BazaarCore.Services.WebApi.Models;

namespace PM.BazaarCore.Services.WebApi.Mapper
{
    public class CategoryToModel : Profile
    {
        public CategoryToModel()
        {
            CreateMap<Category, CategoryModel>();
        }
    }
}
