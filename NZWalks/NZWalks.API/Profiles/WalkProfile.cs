﻿using AutoMapper;

namespace NZWalks.API.Profiles
{
    public class WalkProfile : Profile
    {
        public WalkProfile()
        {
            CreateMap<Models.Domain.Walk, Models.DTOs.Walk>()
                .ReverseMap();
            CreateMap<Models.Domain.WalkDifficulty, Models.DTOs.WalkDifficulty>()
                .ReverseMap();
        }
    }
}
