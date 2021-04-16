using System.Collections.Generic;
using System;

namespace Backend_Dev_Eindwerk.DTO
{
    public class SponsorDTO
    {
        
        public string Name { get; set; }
        public List<Guid> Leagues {get;set;}
    }
}
