using System;

namespace Backend_Dev_Eindwerk.Models
{
    public class LeagueSponsor
    {

        public Guid LeagueId {get;set;}

        public Guid SponsorId {get;set;}

        public Sponsor Sponsor { get; set; }
    }
}
