using System;

namespace Benchmark_Test
{
    class Program
    {
        static void Main(string[] args)
        {
            //PoolItem.DataCellPoolInit();
            //PoolItem.DataUnitPoolInit();
            //Create_Pool create_Pool = new Create_Pool();
            //DataUnit du = create_Pool.CollectDataPool(PoolItem.ListParams);

            BenchmarkDotNet.Running.BenchmarkRunner.Run<Demo>();
            Console.WriteLine("Hello World!");
        }
    }
}
