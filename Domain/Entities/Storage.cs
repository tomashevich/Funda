using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

namespace Domain.Entities
{
    public class Storage
    {
        public Storage()
        {
            Makelaars = new ConcurrentDictionary<long, Item>();
        }

        private ConcurrentDictionary<long, Item> Makelaars { get; }
        public bool TryAdd(Aanbod toAdd)
        {
            Makelaars.AddOrUpdate(toAdd.MakelaarId, new Item { Name = toAdd.MakelaarName, Count = 1 }, (k, v) => { v.Count++; return v; }
            );
            return true;
        }
        public bool Clear() { return true; }

        public List<MakelaarsDto> GetTopMakelaars(int num)
        {
            var result = Makelaars.Select(m => new MakelaarsDto { MakelaarId = m.Key, Name = m.Value.Name, NumOfProposals = m.Value.Count }).OrderBy(i => i.NumOfProposals);

            return result.TakeLast(num).Reverse().ToList(); 
        }


    }

    public struct Item
    {
        public string Name { get; set; }
        public int Count { get; set; }
    }
    public class Aanbod
    {
        public string MakelaarName { get; set; }
        public long MakelaarId { get; set; }

    }
    public class MakelaarsDto //: IMapFrom<GetAllPostsResponse>
    {
        public long MakelaarId { get; set; }
        public string Name { get; set; }
        public int NumOfProposals { get; set; }

    }
}