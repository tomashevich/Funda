using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Infrastructure.FundaApi
{
    public class AanbodResponceDto
    {
        [JsonPropertyName("Objects")]
        public List<Proposal> Objects { get; set; }

        [JsonPropertyName("Paging")]
        public Paging Paging { get; set; }

        [JsonPropertyName("TotaalAantalObjecten")]
        public int TotaalAantalObjecten { get; set; }
    }

    public class Proposal
    {

        [JsonPropertyName("Id")]
        public Guid Id { get; set; }

        [JsonPropertyName("Adres")]
        public string Adres { get; set; }

        [JsonPropertyName("MakelaarId")]
        public long MakelaarId { get; set; }

        [JsonPropertyName("MakelaarNaam")]
        public string MakelaarNaam { get; set; }


    }

    public class Paging
    {
        /// <summary>
        /// total pages
        /// </summary>
        [JsonPropertyName("AantalPaginas")]
        public int AantalPaginas { get; set; }

        /// <summary>
        /// current page
        /// </summary>
        [JsonPropertyName("HuidigePagina")]
        public int HuidigePagina { get; set; }
    }
}
