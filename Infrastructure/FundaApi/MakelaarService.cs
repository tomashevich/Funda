using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Domain;
using Application.Posts.Queries.GetAllPosts;
using Domain.Entities;

namespace Infrastructure.FundaApi
{
    public class MakelaarService : IMakelaarApi

    {
        private readonly IAanbodApi _client;

        public MakelaarService(IAanbodApi client)
        {
            _client = client;
        }

        public async Task<IEnumerable<MakelaarsDto>> GetAll()
        {
            var storage = new Storage();

            var data = await _client.GetAll(1).ConfigureAwait(false); ;

            var totalPages = data.Paging?.AantalPaginas;

            var tasks = new List<Task>();

            tasks.Add(Task.Run(() =>
              {
                  foreach (var item in data.Objects)
                  {
                      storage.TryAdd(new Aanbod { MakelaarId = item.MakelaarId, MakelaarName = item.MakelaarNaam });
                  }
              }));

            if (totalPages > 1)
            {
                for (int i = 2; i <= totalPages; i++)
                {
                    tasks.Add(ProceedNextBatch(i,  storage));
                }
            }

            await Task.WhenAll(tasks).ConfigureAwait(false);

            var result = storage.GetTopMakelaars(10);
            return result;
        }


        private async Task ProceedNextBatch(int pageNum, Storage storage)
        {
            var data = await _client.GetAll(pageNum);

            foreach (var item in data.Objects)
            {
                storage.TryAdd(new Aanbod { MakelaarId = item.MakelaarId, MakelaarName = item.MakelaarNaam });
            }
        }


        public Task<IEnumerable<GetAllPostsResponse>> GetAllWithTuin()
        {
            throw new System.NotImplementedException();
        }

     
    }
}