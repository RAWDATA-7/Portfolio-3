using AutoMapper;
using DataServiceLib.Domain;
using DataServiceLib.FuncDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
