using AutoMapper;
using DataServiceLib.FuncDomain;

namespace WebService.ViewModels.Profiles
{
    public class BestMatchProfile : Profile
    {
        public BestMatchProfile()
        {
            CreateMap<BestMatch, BestMatchListViewModel>();
        }
    }
}
