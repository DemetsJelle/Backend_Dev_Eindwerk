using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Backend_Dev_Eindwerk.Models
{
    public class Team
    {
        public Guid TeamId { get; set; }

        [Required(ErrorMessage ="Naam team verplicht")]
        public string Name { get; set; }

        [Required(ErrorMessage ="Afkorting team verplicht")]
        public string Abbreviation { get; set; }

        public string LandOfOrigen { get; set; }

        public Guid LeagueId { get; set; }

        public List<Player> Players{get;set;}
    }
}
