using System.Threading.Tasks;

namespace Infrastructure.FundaApi
{
    public interface IAanbodApi
    {
        Task<AanbodResponceDto> GetAll(int PageNum);
        Task<AanbodResponceDto> GetAllWithTuin(int pageNum);
    }
}