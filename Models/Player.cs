using System;
using System.Text.Json.Serialization;

namespace Backend_Dev_Eindwerk.Models
{
    public class Player
    {
        public Guid PlayerId { get; set; }
        public String Name { get; set; }
        public String Ign { get; set; }

        public String DateOfBirth { get; set; }

        public String Nationality { get; set; }

        //[JsonIgnore]
        public Guid TeamId {get;set;}

        [JsonIgnore]    
        public Team team {get;set;}

    }
}
