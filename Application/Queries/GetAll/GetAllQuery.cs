using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;

namespace Application.Queries.GetAll
{
    public class GetAllQuery : IRequest<IEnumerable<GetAllDto>>
    {
        public class GetAllQueryHandler : IRequestHandler<GetAllWithTuinQuery, IEnumerable<GetAllDto>>
        {
            private readonly IMakelaarService _makelaarApi;
            private readonly IMapper _mapper;

            public GetAllQueryHandler(IMakelaarService postsApi, IMapper mapper)
            {
                _makelaarApi = postsApi;
                _mapper = mapper;
            }
            
            public async Task<IEnumerable<GetAllDto>> Handle(GetAllWithTuinQuery request, CancellationToken cancellationToken)
            {
                var posts = await _makelaarApi.GetAll();
                return _mapper.Map<IEnumerable<GetAllDto>>(posts);
            }
        }
    }
}