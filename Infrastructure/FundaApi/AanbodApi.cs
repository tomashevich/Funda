using System.Collections.Generic;
using System.Threading.Tasks;


namespace Infrastructure.FundaApi
{
    public class AanbodApi : IAanbodApi

    {
        private readonly IFundaApiClient _fundaApiClient;

        public AanbodApi(IFundaApiClient client)
        {
            _fundaApiClient = client;
        }
        
        public async Task<AanbodResponceDto> GetAll(int pageNum)
        {
            return await _fundaApiClient.GetAll(pageNum);
        }

        public async Task<AanbodResponceDto> GetAllWithTuin(int pageNum)
        {
            return await _fundaApiClient.GetAllWithTuin(pageNum);
        }
    }
}