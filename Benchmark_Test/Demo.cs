using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Benchmark_Test
{
 
    [MaxColumn][MinColumn][MemoryDiagnoser]
    //[SimpleJob(BenchmarkDotNet.Jobs.RuntimeMoniker.CoreRt21)]
    //[SimpleJob(BenchmarkDotNet.Jobs.RuntimeMoniker.CoreRt31)]
    //MaxColumn最大耗时时间  MinColumn最小耗时时间 MemoryDiagnoser内存使用时间
    public class Demo
    {
        //Create_Pool Create_Pool=new Create_Pool()
        //[Params("https://www.baidu.com/img/bd_logo1.png", "https://www.baidu.com/img/bd_logo2.png")]

        //public string Content { get; set; }

        [Benchmark]
        public void Get()
        {
            Create_Pool create_Pool = new Create_Pool();
            for (int i = 0; i < 10000; i++)
            {
                DataUnit du = create_Pool.CollectData(PoolItem.ListParams);
            }
            //du.Clear();
            //PoolItem.DataUnitPools.Enqueue(du);
            //Console.WriteLine($"DataCellPools:{PoolItem.DataCellPools.Count} DataUnitPools:{PoolItem.DataUnitPools.Count}");
        }

        [Benchmark]
        public void Get_Pool()
        {
            Create_Pool create_Pool = new Create_Pool();
            for (int i = 0; i < 10000; i++)
            {
                DataUnit du = create_Pool.CollectDataPool(PoolItem.ListParams);
                du.Clear();
            }
            //Console.WriteLine($"DataCellPools:{PoolItem.DataCellPools.Count} DataUnitPools:{PoolItem.DataUnitPools.Count}");
        }
    }
}
