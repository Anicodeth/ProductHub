using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Domain.Entities;
using Application.DTOs.UserDTOs;
using Application.DTOs.ProductDTOs;
using AutoMapper;

namespace Application.Profiles
{

    public class MappingProfile :Profile
    {

        public MappingProfile()
        {
            CreateMap<Product, ProductDTO>();
            CreateMap<ProductCreationDTO, Product>();
            CreateMap<ProductUpdateDTO, Product>();
            CreateMap<Product, ProductSearchDTO>();


            CreateMap<User, UserDTO>();
            CreateMap<CreateUserDTO, User>();
            CreateMap<UpdateUserDTO, User>();
            CreateMap<LoginUserDTO, User>(); 


        }
    }
}
