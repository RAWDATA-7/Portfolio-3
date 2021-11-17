﻿using AutoMapper;
using DataServiceLib.Domain;

namespace WebService.ViewModels.Profiles
{
    public class TitleProfile : Profile
    {
        public TitleProfile()
        {
            CreateMap<Title, TitleViewModel>();
        }
    }
}
