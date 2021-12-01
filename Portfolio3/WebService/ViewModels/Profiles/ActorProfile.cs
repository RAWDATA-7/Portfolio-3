using AutoMapper;
using DataServiceLib.Domain;


namespace WebService.ViewModels.Profiles
{
    public class ActorProfile : Profile
    {
        public ActorProfile()
        {
            CreateMap<Actor, ActorViewModel>();
           //     .ForMember(dst => dst.Professions, src => src.MapFrom(x => x.Professions.Select(z => z.Name)));
        }
    }
}