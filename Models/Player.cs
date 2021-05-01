using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Backend_Dev_Eindwerk.Models
{
    public class Player
    {
        public Guid PlayerId { get; set; }

        [Required(ErrorMessage ="Name player required")]
        public String Name { get; set; }

        [Required(ErrorMessage ="Ingame name required")]
        public String Ign { get; set; }

        [Required(ErrorMessage ="Date of brith required")]
        [DateOfBirthAttribute]
        public String DateOfBirth { get; set; }

        public String Nationality { get; set; }

        //[JsonIgnore]
        public Guid TeamId {get;set;}

        [JsonIgnore]    
        public Team team {get;set;}

    }
}
