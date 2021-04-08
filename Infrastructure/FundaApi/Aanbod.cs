using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Posts.Queries.GetAllPosts;

namespace Infrastructure.FundaApi
{
    public class AanbodApi : IAanbodApi

    {
        private readonly FundaApiClient _client;

        public AanbodApi(FundaApiClient client)
        {
            _client = client;
        }
        
     

        //public async Task<CreatePostResponse> CreatePost(CreatePostRequest request)
        //{
        //    return await _client.CreatePost(request);
        //}

        public async Task<AanbodResponceDto> GetAll(int pageNum)
        {
            return await _client.GetAll(pageNum);
        }

        public Task<object> GetAllWithTuin()
        {
            throw new System.NotImplementedException();
        }
    }
}