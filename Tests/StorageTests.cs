using Domain.Entities;
using Shouldly;
using Xunit;

namespace Tests
{
    public class StorageTests
    {
        [Fact]
        public  void Storage_should_count_correctly()
        {
            //arrange
            var storage = new Storage();

            for (var i = 0; i < 10; i++)
            {
                SendDataIntoStorage(storage, i);
            }

            //act
            var result = storage.GetTopMakelaars(10);

            //assert
            result.Count.ShouldBe(10);
            for (var i = 0; i < 10; i++)
            {
                result[i].NumOfProposals.ShouldBe(10-i);
            }
            storage.RecordsProceeded.ShouldBe(55);
        }

        private static void SendDataIntoStorage(Storage storage, long id)
        {
            for (var i = 30-id; i<=30; i++)
                storage.TryAdd(new Aanbod { MakelaarId = 30 - id, MakelaarName = $"MakelaarNaam_{30 - id}"});
        }
    }
}
