using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Backend_Dev_Eindwerk.Models
{
    public class Sponsor
    {
        public Guid SponsorId { get; set; }

        [Required(ErrorMessage ="Naam sponsor verplicht")]
        public String Name { get; set; }

        [JsonIgnore]
        public List<LeagueSponsor> LeagueSponsors {get;set;}
    }
}
