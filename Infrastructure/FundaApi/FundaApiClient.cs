using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;


namespace Infrastructure.FundaApi
{
    public class FundaApiClient : BaseHttpClient, IFundaApiClient
    {
        //move to configs
        private string _key;
        public FundaApiClient(HttpClient httpClient) : base(httpClient)
        {
            _key = "ac1b0b1572524640a0ecc54de453ea9f";
        }

        public async Task<AanbodResponceDto> GetAll(int pageNum = 1)
        {           
            return await Get<AanbodResponceDto>(Endpoints.Aanbod.GetAll(_key,"amsterdam", pageNum, 25));
        }

        public async Task<AanbodResponceDto> GetAllWithTuin(int pageNum = 1)
        {         
            return await Get<AanbodResponceDto>(Endpoints.Aanbod.GetAll(_key, "amsterdam/tuin", pageNum, 25));
        }
    }
}