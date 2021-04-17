using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Backend_Dev_Eindwerk.Models
{
    public class League
    {
        public Guid LeagueId { get; set; }
        public string Name { get; set; }
        public string Abbreviation { get; set; }
        public string Region { get; set; }

        [JsonIgnore]
        public List<LeagueSponsor> LeagueSponsors {get;set;}
    }
}
