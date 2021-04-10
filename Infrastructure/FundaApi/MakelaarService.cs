using System.Collections.Generic;
using System.Threading.Tasks;
using Application;

using Domain.Entities;

namespace Infrastructure.FundaApi
{
    public class MakelaarService : IMakelaarService
    {
        private readonly IAanbodApi _aanbodApiclient;
        private const int TOP_COUNT = 10;
        public MakelaarService(IAanbodApi client)
        {
            _aanbodApiclient = client;
        }

        public async Task<MakelaarsResponceDto> GetAll()
        {
            var storage = new Storage();

            //get first bunch of records to find total page numbers

            //todo: check data not null and so on...
            try
            {
                var data = await _aanbodApiclient.GetAll(1).ConfigureAwait(false);
                var totalPages = data.Paging?.AantalPaginas;
                storage.TotalRecords = data.TotaalAantalObjecten;

                var tasks = new List<Task>();

                tasks.Add(Task.Run(() =>
                  {
                      SendDataIntoStorage(storage, data);
                  }));


                //retrieve all data that left
                if (totalPages > 1)
                {
                    for (int i = 2; i <= totalPages; i++)
                        tasks.Add(ProceedNextBatch(i, storage, withTuin: false));
                }

                await Task.WhenAll(tasks).ConfigureAwait(false);
            }
            catch { }
            var result = new MakelaarsResponceDto
            {
                Makelaars = storage.GetTopMakelaars(TOP_COUNT),
                RecordsProceeded = storage.RecordsProceeded,
                TotalRecords = storage.TotalRecords
            };
            return result;
        }

        public async Task<MakelaarsResponceDto> GetAllWithTuin()
        {
            var storage = new Storage();

            //get first bunch of records to find total page numbers


            try
            {
                //todo: check data not null and so on...
                var data = await _aanbodApiclient.GetAllWithTuin(1).ConfigureAwait(false);
                var totalPages = data.Paging?.AantalPaginas;
                storage.TotalRecords = data.TotaalAantalObjecten;

                var tasks = new List<Task>();
                tasks.Add(Task.Run(() =>
                {
                    SendDataIntoStorage(storage, data);
                }));

                //retrieve all data that left
                if (totalPages > 1)
                {
                    for (int i = 2; i <= totalPages; i++)
                        tasks.Add(ProceedNextBatch(i, storage, withTuin: true));
                }

                await Task.WhenAll(tasks).ConfigureAwait(false);
            }
            catch { }
            var result = new MakelaarsResponceDto
            {
                Makelaars = storage.GetTopMakelaars(TOP_COUNT),
                RecordsProceeded = storage.RecordsProceeded,
                TotalRecords = storage.TotalRecords
            };
            return result;
        }

        private async Task ProceedNextBatch(int pageNum, Storage storage, bool withTuin)
        {
            AanbodResponceDto data;
            if (withTuin)
                data = await _aanbodApiclient.GetAllWithTuin(pageNum).ConfigureAwait(false);
            else
                data = await _aanbodApiclient.GetAll(pageNum).ConfigureAwait(false); 

            SendDataIntoStorage(storage, data);
        }
       
        private static void SendDataIntoStorage(Storage storage, AanbodResponceDto data)
        {
            foreach (var item in data.Objects)
                storage.TryAdd(new Aanbod { MakelaarId = item.MakelaarId, MakelaarName = item.MakelaarNaam });
        }
    }
}