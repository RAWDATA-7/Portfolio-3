using AutoMapper;
using DataServiceLib.FuncDomain;

namespace WebService.ViewModels.Profiles
{
    public class BestRatedTitleProfile : Profile
    {
        public BestRatedTitleProfile()
        {
            CreateMap<BestRatedTitle, BestRatedTitleListViewModel>();
        }
    }
}
