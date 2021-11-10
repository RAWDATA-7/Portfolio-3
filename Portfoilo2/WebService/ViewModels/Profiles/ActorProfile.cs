using AutoMapper;
using DataServiceLib.Domain;
using DataServiceLib.FuncDomain;


namespace WebService.ViewModels.Profiles
{
    public class ActorProfile : Profile
    {
        public ActorProfile()
        {
            CreateMap<Actor, ActorViewModel>();
            CreateMap<Actor, ActorListViewModel>();
        }
    }
}