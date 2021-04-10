using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Application
{
    public class MakelaarsResponceDto
    {      
        public List<Makelaar> Makelaars { get; set; }        
        public int RecordsProceeded { get; set; }       
        public int TotalRecords { get; set; }
    }
}
