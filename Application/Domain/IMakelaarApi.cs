using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Posts.Queries.GetAllPosts;
using Domain.Entities;

namespace Application.Domain

{
    public interface IMakelaarApi
    {
        Task<IEnumerable<MakelaarsDto>> GetAll();
        Task<IEnumerable<GetAllPostsResponse>> GetAllWithTuin();
    }
}