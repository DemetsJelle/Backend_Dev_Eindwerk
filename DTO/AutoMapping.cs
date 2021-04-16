using System;
using System.Collections.Generic;
using AutoMapper;
using Backend_Dev_Eindwerk.Models;

namespace Backend_Dev_Eindwerk.DTO
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<LeagueDTO , League>();
            CreateMap<SponsorDTO , Sponsor>(); 
        }
    }
}
