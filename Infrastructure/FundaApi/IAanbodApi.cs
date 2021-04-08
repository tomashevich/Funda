using System.Threading.Tasks;

namespace Infrastructure.FundaApi
{
    public interface IAanbodApi
    {
        Task<AanbodResponceDto> GetAll(int PageNum);
        Task<object> GetAllWithTuin();
    }
}