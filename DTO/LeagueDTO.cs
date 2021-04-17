using System;
using System.Collections.Generic;
using Backend_Dev_Eindwerk.Models;

namespace Backend_Dev_Eindwerk.DTO
{
    public class LeagueDTO
    {
        public Guid LeagueId { get; set; }
        public string Name {get;set;}

        public List<LeagueSponsor> LeagueSponsors {get;set;}
    }
}
