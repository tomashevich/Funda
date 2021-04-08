using Application.Common.Mappings;
using AutoMapper;
using Domain.Entities;

namespace Application.Queries.GetAll
{
    public class GetAllDto : IMapFrom<Makelaars>
    {
        public long MakelaarId { get; set; }
        public string Name { get; set; }
        public int NumOfProposals { get; set; }
     
       

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Makelaars, GetAllDto>();
        }
    }
}