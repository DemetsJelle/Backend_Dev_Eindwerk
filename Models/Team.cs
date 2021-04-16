using System;

namespace Backend_Dev_Eindwerk.Models
{
    public class Team
    {
        public Guid TeamId { get; set; }

        public string Name { get; set; }

        public string Abbreviation { get; set; }

        public string LandOfOrigen { get; set; }

        public Guid LeagueId { get; set; }
    }
}
