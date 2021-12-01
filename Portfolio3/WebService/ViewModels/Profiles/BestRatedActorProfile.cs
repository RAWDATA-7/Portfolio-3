using AutoMapper;
using DataServiceLib.FuncDomain;

namespace WebService.ViewModels.Profiles
{
    public class BestRatedActorProfile : Profile
    {
        public BestRatedActorProfile()
        {
            CreateMap<BestRatedActor, BestRatedActorListViewModel>();
        }
    }
}
