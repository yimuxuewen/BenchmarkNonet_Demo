using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using System.Threading;

namespace Benchmark_Test
{
    public class DataUnit
    {
        public string MeasurementName { get; set; }
        public DateTime Datetime { get; set; }

        public Dictionary<string, string> tags = new Dictionary<string, string>();

        public List<DataCell> listCells = new List<DataCell>();
        [JsonIgnore]
        public string policy { get; set; }

        public volatile int UsingFlag = 0;

        public void AddTick(int nano)
        {
            Datetime.AddTicks(nano);
        }
        public void Clear()
        {
            MeasurementName = string.Empty;
            tags.Clear();
            foreach (var item in listCells)
            {
                item.Clear();
            }
            listCells.Clear();
            policy = string.Empty;
            PoolItem.DataUnitPools.Enqueue(this);
        }


    }
}
