﻿using AutoMapper;
using Receivables.Bll.Dto;
using Receivables.Dal.Models;
using Receivables.Models;

namespace Receivables
{
    public class AutomapperConfig : Profile
    {
        public AutomapperConfig()
        {
            CreateMap<ApplicationUser, UserDto>();
            CreateMap<UserDto, LoginModel>();
            CreateMap<UserDto, RegisterModel>();
            CreateMap<UserDto, ApplicationUser>();
            CreateMap<LoginModel, UserDto>();
            CreateMap<RegisterModel, UserDto>();
            CreateMap<StoreDto, Store>();
            CreateMap<Store, StoreDto>();
            CreateMap<StoreViewModel, StoreDto>();
            CreateMap<StoreDto, StoreViewModel>();
        }
    }
}