using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application;
using Domain.Entities;
using Microsoft.Extensions.Logging;

namespace Infrastructure.FundaApi
{
    public class MakelaarService : IMakelaarService
    {
        private readonly IAanbodApi _aanbodApiclient;
        private const int TOP_COUNT = 10;
        private readonly ILogger<MakelaarService> _logger;
        public MakelaarService(IAanbodApi client, ILogger<MakelaarService> logger)
        {
            _aanbodApiclient = client;
            _logger = logger;
        }

        public async Task<MakelaarsResponceDto> GetAll(bool withTuin = false)
        {
            var storage = new Counter();

            try
            {
                //get first bunch of records to find total page numbers
                AanbodResponceDto data;
                if (!withTuin)
                    data = await _aanbodApiclient.GetAll(1).ConfigureAwait(false);
                else
                    data = await _aanbodApiclient.GetAllWithTuin(1).ConfigureAwait(false);

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
                        tasks.Add(ProceedNextBatch(i, storage, withTuin));
                }

                await Task.WhenAll(tasks).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                _logger.LogError($"Exception: {e.Message}.  Inner Exception: {e.InnerException}" );
            }

            var result = new MakelaarsResponceDto
            {
                Makelaars = storage.GetTopMakelaars(TOP_COUNT),
                RecordsProceeded = storage.RecordsProceeded,
                TotalRecords = storage.TotalRecords
            };
            return result;
        }

        private async Task ProceedNextBatch(int pageNum, Counter storage, bool withTuin)
        {
            AanbodResponceDto data;
            if (withTuin)
                data = await _aanbodApiclient.GetAllWithTuin(pageNum).ConfigureAwait(false);
            else
                data = await _aanbodApiclient.GetAll(pageNum).ConfigureAwait(false);

            SendDataIntoStorage(storage, data);
        }

        private static void SendDataIntoStorage(Counter storage, AanbodResponceDto data)
        {
            foreach (var item in data.Objects)
                storage.TryAdd(new Aanbod { MakelaarId = item.MakelaarId, MakelaarName = item.MakelaarNaam });
        }
    }
}