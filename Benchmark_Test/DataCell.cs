using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Newtonsoft.Json;

namespace Benchmark_Test
{
    public class DataCell/*:ICloneable*/
    {
        public string pKey { get; set; }

        public string pValue { get; set; }

        public int Cycle { get; set; }
        [JsonIgnore]
        public bool IsTecParam { get; set; }
        [JsonIgnore]
        public string CollectionAddress { get; set; }
        [JsonIgnore]
        public string Address { get; set; }

        public volatile int UsingFlag = 0;

        public void Clear()
        {
            pKey = string.Empty;
            pValue = string.Empty;
            Cycle = 0;
            IsTecParam = false;
            CollectionAddress = string.Empty;
            Address = string.Empty;
            PoolItem.DataCellPools.Enqueue(this);
        }


        //public object Clone()
        //{
        //    return (DataCell)base.MemberwiseClone() ;
        //}
    }
}
