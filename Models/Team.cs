using System;
using System.Collections.Generic;

namespace Backend_Dev_Eindwerk.Models
{
    public class Team
    {
        public Guid TeamId { get; set; }

        public string Name { get; set; }

        public string Abbreviation { get; set; }

        public string LandOfOrigen { get; set; }

        public Guid LeagueId { get; set; }

        public List<Player> Players{get;set;}
    }
}
