using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Queries.GetAll
{
    public class GetAllWithTuinQuery : IRequest<GetAllDto>
    {
        public class GetAllWithTuinQueryHandler : IRequestHandler<GetAllWithTuinQuery, GetAllDto>
        {
            private readonly IMakelaarService _makelaarApi;
            private readonly IMapper _mapper;

            public GetAllWithTuinQueryHandler(IMakelaarService postsApi, IMapper mapper)
            {
                _makelaarApi = postsApi;
                _mapper = mapper;
            }
            
            public async Task<GetAllDto> Handle(GetAllWithTuinQuery request, CancellationToken cancellationToken)
            {
               
                  var result = await _makelaarApi.GetAllWithTuin();
             
                return _mapper.Map<GetAllDto>(result);
            }
        }
    }
}