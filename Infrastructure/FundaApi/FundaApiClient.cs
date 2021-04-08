using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Application.Posts.Queries.GetAllPosts;

namespace Infrastructure.FundaApi
{
    public class FundaApiClient : BaseHttpClient
    {
        //move to configs
        private string _key;
        public FundaApiClient(HttpClient httpClient) : base(httpClient)
        {
            _key = "ac1b0b1572524640a0ecc54de453ea9f";
        }

        public async Task<AanbodResponceDto> GetAll(int pageNum = 1)
        {
            //add responce dto
            return await Get<AanbodResponceDto>(Endpoints.Aanbod.GetAll(_key,"amsterdam", pageNum, 25));
        }

        //public async Task<CreatePostResponse> CreatePost(CreatePostRequest request)
        //{
        //    return await Post<CreatePostResponse>(Endpoints.Aanbod.CreatePost, request);
        //}
    }
}