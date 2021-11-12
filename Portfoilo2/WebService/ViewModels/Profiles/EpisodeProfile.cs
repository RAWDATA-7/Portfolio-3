using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DataServiceLib.Domain;

namespace WebService.ViewModels.Profiles
{
    public class EpisodeProfile : Profile
    {
        public EpisodeProfile()
        {
            CreateMap<Episode, EpisodeViewModel>();
            CreateMap<Episode, EpisodeListViewModel>();
        }
    }
}
