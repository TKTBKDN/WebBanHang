using AutoMapper;
using Commerce.Repository.Entities;
using Commerce.Repository.Models;

namespace Commerce.Repository.Helper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // create mapper 
            CreateMap<UserModel, User>().ReverseMap();
            CreateMap<CategoryModel, Category>().ReverseMap();
        }
    }
}
