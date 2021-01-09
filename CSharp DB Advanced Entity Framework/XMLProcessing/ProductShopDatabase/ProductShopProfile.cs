namespace ProductShopDatabase
{
    using AutoMapper;
    using ProductShopDatabase.Dto;
    using ProductShopDatabase.Models;

    public class ProductShopProfile : Profile
    {
        public ProductShopProfile()
        {
            CreateMap<UserDto, User>();
            CreateMap<ProductDto, Product>();
            CreateMap<CategoryDto, Category>();
            CreateMap<ProductsInRangeDto, Product>();
        }
    }
}
