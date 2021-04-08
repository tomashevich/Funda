using System.Collections.Generic;
using System.Threading.Tasks;

using Domain.Entities;

namespace Application

{
    public interface IMakelaarService
    {
        Task<IEnumerable<Makelaars>> GetAll();
        Task<IEnumerable<Makelaars>> GetAllWithTuin();
    }
}