using AutoMapper;
using DataServiceLib.Domain;

namespace WebService.ViewModels.Profiles
{
    public class AkaProfile : Profile
    {
        public AkaProfile()
        {
            CreateMap<Aka, AkaViewModel>();
        }
    }
}
