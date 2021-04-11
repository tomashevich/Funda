using Application.Common.Mappings;
using AutoMapper;
using Domain.Entities;
using System.Collections.Generic;

namespace Application.Queries.GetAll
{
    public class GetAllDto : IMapFrom<MakelaarsResponceDto>
    {
        public List<Makelaar> Makelaars { get; set; }
        public int RecordsProceeded { get; set; }
        public int TotalRecords { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<MakelaarsResponceDto, GetAllDto>();
        }
    }
}