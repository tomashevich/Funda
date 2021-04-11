using System.Threading.Tasks;

namespace Infrastructure.FundaApi
{
    public interface IFundaApiClient
    {
        Task<AanbodResponceDto> GetAll(int pageNum);
        Task<AanbodResponceDto> GetAllWithTuin(int pageNum);
    }
}