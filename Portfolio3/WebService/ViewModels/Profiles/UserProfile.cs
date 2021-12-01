using AutoMapper;
using DataServiceLib.Domain;

namespace WebService.ViewModels.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserViewModel>();
        }
    }
}