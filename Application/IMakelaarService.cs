using System.Threading.Tasks;

namespace Application
{
    public interface IMakelaarService
    {
        Task<MakelaarsResponceDto> GetAll(bool withTuin);
    }
}