using Domain.Entities;
using System.Collections.Generic;

namespace Application
{
    public class MakelaarsResponceDto
    {      
        public List<Makelaar> Makelaars { get; set; }        
        public int RecordsProceeded { get; set; }       
        public int TotalRecords { get; set; }
    }
}
