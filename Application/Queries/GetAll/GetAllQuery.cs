using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Queries.GetAll
{
    public class GetAllQuery : IRequest<GetAllDto>
    {
        public class GetAllQueryHandler : IRequestHandler<GetAllQuery, GetAllDto>
        {
            private readonly IMakelaarService _makelaarApi;
            private readonly IMapper _mapper;

            public GetAllQueryHandler(IMakelaarService postsApi, IMapper mapper)
            {
                _makelaarApi = postsApi;
                _mapper = mapper;
            }
            
            public async Task<GetAllDto> Handle(GetAllQuery request, CancellationToken cancellationToken)
            {
               
                   var result = await _makelaarApi.GetAll();
              
                return _mapper.Map<GetAllDto>(result);
            }
        }
    }
}