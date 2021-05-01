using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Backend_Dev_Eindwerk.Models
{
    public class League
    {

        public Guid LeagueId { get; set; }

        [Required(ErrorMessage ="Naam league verplicht")]
        public string Name { get; set; }

        [Required(ErrorMessage ="Afkorting league verplicht")]
        public string Abbreviation { get; set; }

        [Required(ErrorMessage ="Regio league verplicht")]
        public string Region { get; set; }

        [JsonIgnore]
        public List<LeagueSponsor> LeagueSponsors {get;set;}
    }
}
