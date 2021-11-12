using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
