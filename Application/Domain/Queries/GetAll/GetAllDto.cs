using Application.Common.Mappings;
using AutoMapper;
using Domain.Entities;

namespace Application.Domain.Queries.GetAll
{
    public class GetAllDto : IMapFrom<MakelaarsDto>
    {
        public long MakelaarId { get; set; }
        public string Name { get; set; }
        public int NumOfProposals { get; set; }
     
       

        public void Mapping(Profile profile)
        {
            profile.CreateMap<MakelaarsDto, GetAllDto>();
        }
    }
}