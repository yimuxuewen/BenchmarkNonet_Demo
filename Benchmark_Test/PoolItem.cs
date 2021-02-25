using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;

namespace Benchmark_Test
{
    public static class PoolItem
    {
        public static ConcurrentQueue<DataCell> DataCellPools = DataCellPoolInit();

        public static ConcurrentQueue<DataUnit> DataUnitPools = DataUnitPoolInit();


        public static List<ParamBase> ListParams = new List<ParamBase>() {
        new ParamBase(){PCode="T1",Value="T1",Address="501A.Code",Cycle=-1},
        new ParamBase(){PCode="T2",Value="T2",Address="501A.DateTime",Cycle=-2},
        new ParamBase(){PCode="T3",Value="T3",Address="501A.Name"},
        new ParamBase(){PCode="T4",Value="T4",Address="501A.Value"},
        new ParamBase(){PCode="T5",Value="T5",Address="501A.Limit"},
        new ParamBase(){PCode="T6",Value="T6",Address="501A.Scale"},
        new ParamBase(){PCode="T7",Value="T7",Address="501A.Position"},
        new ParamBase(){PCode="T8",Value="T8",Address="501A.Empployee"},
        };

        private static ConcurrentQueue<DataCell> DataCellPoolInit()
        {
            ConcurrentQueue<DataCell> _dataCellPools= new ConcurrentQueue<DataCell>();
            for (int i = 0; i < 900; i++)
            {
                _dataCellPools.Enqueue(new DataCell());
            }
            return _dataCellPools;
        }

        private static ConcurrentQueue<DataUnit> DataUnitPoolInit()
        {
            ConcurrentQueue<DataUnit> _dataUnitPools = new ConcurrentQueue<DataUnit>();
            for (int i = 0; i < 100; i++)
            {
                _dataUnitPools.Enqueue(new DataUnit());
            }
            return _dataUnitPools;
        }

    }
}
