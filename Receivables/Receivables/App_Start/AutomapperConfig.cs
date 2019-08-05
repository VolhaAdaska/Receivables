using AutoMapper;
using Receivables.DAL.Models;
using Receivables.DAL.Models.Identity;
using Receivables.DTO;
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
            CreateMap<StoreTypeDto, StoreType>();
            CreateMap<StoreType, StoreTypeDto>();
            CreateMap<StoreTypeDto, StoreTypeViewModel>();
            CreateMap<StoreTypeViewModel, StoreTypeDto>();
        }
    }
}