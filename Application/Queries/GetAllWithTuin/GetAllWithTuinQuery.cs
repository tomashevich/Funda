using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Queries.GetAll
{
    public class GetAllWithTuinQuery : IRequest<IEnumerable<GetAllDto>>
    {
        public class GetAllWithTuinQueryHandler : IRequestHandler<GetAllWithTuinQuery, IEnumerable<GetAllDto>>
        {
            private readonly IMakelaarService _makelaarApi;
            private readonly IMapper _mapper;

            public GetAllWithTuinQueryHandler(IMakelaarService postsApi, IMapper mapper)
            {
                _makelaarApi = postsApi;
                _mapper = mapper;
            }
            
            public async Task<IEnumerable<GetAllDto>> Handle(GetAllWithTuinQuery request, CancellationToken cancellationToken)
            {
                IEnumerable<Makelaars> posts = new List<Makelaars>();
                try
                {
                     posts = await _makelaarApi.GetAllWithTuin();
                }
                catch (Exception ex)
                { 
                    //add logging
                }
                return _mapper.Map<IEnumerable<GetAllDto>>(posts);
            }
        }
    }
}