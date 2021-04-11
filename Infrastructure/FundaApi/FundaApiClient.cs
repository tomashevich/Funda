using System.Net.Http;
using System.Threading.Tasks;


namespace Infrastructure.FundaApi
{
    public class FundaApiClient : BaseHttpClient, IFundaApiClient
    {      
        private string _key;
        private int _itemsOnPage; 
        public FundaApiClient(HttpClient httpClient) : base(httpClient)
        {
            _key = "ac1b0b1572524640a0ecc54de453ea9f";
            _itemsOnPage = 25;
        }

        public async Task<AanbodResponceDto> GetAll(int pageNum = 1)
        {           
            return await Get<AanbodResponceDto>(Endpoints.Aanbod.GetAll(_key,"amsterdam", pageNum, _itemsOnPage));
        }

        public async Task<AanbodResponceDto> GetAllWithTuin(int pageNum = 1)
        {         
            return await Get<AanbodResponceDto>(Endpoints.Aanbod.GetAll(_key, "amsterdam/tuin", pageNum, _itemsOnPage));
        }
    }
}