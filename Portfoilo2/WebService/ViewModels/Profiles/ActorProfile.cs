using AutoMapper;
using DataServiceLib.Domain;


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