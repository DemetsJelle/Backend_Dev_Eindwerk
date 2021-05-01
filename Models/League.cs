using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Backend_Dev_Eindwerk.Models
{
    public class League
    {

        public Guid LeagueId { get; set; }

        [Required(ErrorMessage ="Name of league required")]
        public string Name { get; set; }

        [Required(ErrorMessage ="Abbreviation league name required")]
        public string Abbreviation { get; set; }

        [Required(ErrorMessage ="Region required")]
        public string Region { get; set; }

        [JsonIgnore]
        public List<LeagueSponsor> LeagueSponsors {get;set;}
    }
}
