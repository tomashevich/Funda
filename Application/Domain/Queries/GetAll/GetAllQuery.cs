using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;

namespace Application.Domain.Queries.GetAll
{
    public class GetAllQuery : IRequest<IEnumerable<GetAllDto>>
    {
        public class GetAllQueryHandler : IRequestHandler<GetAllQuery, IEnumerable<GetAllDto>>
        {
            private readonly IMakelaarApi _makelaarApi;
            private readonly IMapper _mapper;

            public GetAllQueryHandler(IMakelaarApi postsApi, IMapper mapper)
            {
                _makelaarApi = postsApi;
                _mapper = mapper;
            }
            
            public async Task<IEnumerable<GetAllDto>> Handle(GetAllQuery request, CancellationToken cancellationToken)
            {

                //calculate results here
                var posts = await _makelaarApi.GetAll();
                return _mapper.Map<IEnumerable<GetAllDto>>(posts);
            }
        }
    }
}