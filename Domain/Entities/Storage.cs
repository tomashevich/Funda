using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Domain.Entities
{
    public class Storage
    {
        public Storage()
        {
            Makelaars = new ConcurrentDictionary<long, Item>();

        }

        private int recordsProcessed;
        public int TotalRecords { get; set; }
        public int RecordsProceeded { get { return recordsProcessed; } }
        private ConcurrentDictionary<long, Item> Makelaars { get; }

        public bool TryAdd(Aanbod toAdd)
        {
            Makelaars.AddOrUpdate(toAdd.MakelaarId, //key
                new Item { Name = toAdd.MakelaarName, Count = 1 }, //add
                (k, v) => { v.Count++; return v; } //update existing
            );
            Interlocked.Increment(ref recordsProcessed);
            return true;
        }

        public List<Makelaar> GetTopMakelaars(int num)
        {
            var result = Makelaars.Select(m => 
                    new Makelaar { 
                        MakelaarId = m.Key, 
                        Name = m.Value.Name, 
                        NumOfProposals = m.Value.Count })
                .OrderBy(i => i.NumOfProposals);

            return result.TakeLast(num).Reverse().ToList(); 
        }

        
    }

    public struct Item
    {
        public string Name { get; set; }
        public int Count { get; set; }
    }
}