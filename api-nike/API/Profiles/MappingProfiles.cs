using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Dtos;
using AutoMapper;
using Domain.Entities;
namespace API.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<User, UserDto>()
            .ReverseMap();
        CreateMap<Rol, RolDto>()
            .ForMember(dest=>dest.Rol, origen=> origen.MapFrom(origen=> origen.Name.ToString()))
            .ReverseMap();
        CreateMap<User,UserAllDto>()
            .ForMember(dest=>dest.Roles, origen=> origen.MapFrom(origen=> origen.Roles))
            .ReverseMap();

        CreateMap<Bill, BillDto>()
            .ReverseMap();
        CreateMap<Category, CategoryDto>()
            .ReverseMap();
        CreateMap<Client, ClientDto>()
            .ReverseMap();
        CreateMap<ProductDto, ProductDto>()
            .ReverseMap();
        CreateMap<Sale, SaleDto>()
            .ReverseMap();

        CreateMap<Sale, SaleProductDto>()
            .ReverseMap();

        CreateMap<Bill, BillManyProductsDto>()
            .ForMember(dest => dest.ProductList, origen => origen.MapFrom(o => o.Sales))
            .ReverseMap();
    }
}
