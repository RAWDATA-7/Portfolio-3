using System.Linq;
using AutoMapper;
using DataServiceLib.Domain;
using DataServiceLib.FuncDomain;


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