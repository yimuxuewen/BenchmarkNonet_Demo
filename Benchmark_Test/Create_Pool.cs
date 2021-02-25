using System;
using System.Collections.Generic;
using System.Text;

namespace Benchmark_Test
{
    public class Create_Pool
    {
        private int _span = 1;
        private int Span
        {
            get
            {
                if (_span == 9999999)
                {
                    _span = 1;
                }
                return _span;
            }
        }
        public virtual DataUnit CollectData(List<ParamBase> list)
        {
            if (list?.Count > 0)
            {
                DataUnit du = new DataUnit();
                DateTime time = DateTime.Now;
                foreach (var item in list)
                {
                    DataCell dc = new DataCell();
                    switch (item.Cycle)
                    {
                        case -2:

                            try
                            {
                                //DateTime dataTime = DateTime.Parse(item.Value.ToString());
                                DateTime dataTime = DateTime.Now;
                                if (dataTime >  time)
                                {
                                    dataTime = dataTime.AddTicks(Span).ToUniversalTime();
                                    du.Datetime = dataTime.ToUniversalTime();
                                }
                                else
                                {
                                    Console.WriteLine("数据时间错误，无法转换成数据时间!");
                                }

                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine("时间标记不正确", ex);
                                du.Datetime = DateTime.Now.ToUniversalTime();
                            }
                            break;
                        case -1:
                        case -3://Tag标记
                            du.tags.Add("EquipCode", item.Value.ToString().Trim());
                            break;
                        //case -4:
                        //    du.tags.Add(item.PCode.Trim(), item.Value.ToString().Trim());
                        //    break;
                        //case -5:
                        //    du.tags.Add("CellCode", item.Value.ToString().Trim());
                        //    break;
                        default:
                            break;
                    }
                    if (item.Value != null)
                    {
                        dc.pKey = item.PCode;
                        dc.pValue = item.Value;
                        dc.Cycle = item.Cycle;
                        dc.IsTecParam = item.IsTecParam;
                        dc.CollectionAddress = item.CollectionAddress;
                        dc.Address = item.Address;
                        du.listCells.Add(dc);
                    }
                }
                if (!du.tags.ContainsKey("EquipCode"))
                {
                    du.tags.Add("EquipCode", "T-1203");
                }
                if (du.Datetime == default(DateTime))
                {
                    du.Datetime = DateTime.Now.ToUniversalTime();
                }
                du.MeasurementName = "T_B";
                return du;
            }
            else
            {
                return null;
            }
        }


        public virtual DataUnit CollectDataPool(List<ParamBase> list)
        {
            if (list?.Count > 0)
            {
                DataUnit du = PoolItem.DataUnitPools.TryDequeue(out DataUnit dataUnit) ? dataUnit : new DataUnit();
                DateTime time = DateTime.Now;
                foreach (var item in list)
                {
                    DataCell dc = PoolItem.DataCellPools.TryDequeue(out DataCell dataCell) ? dataCell : new DataCell ();
                    switch (item.Cycle)
                    {
                        case -2:

                            try
                            {
                                //DateTime dataTime = DateTime.Parse(item.Value.ToString());
                                DateTime dataTime = DateTime.Now;
                                if (dataTime > time)
                                {
                                    dataTime = dataTime.AddTicks(Span).ToUniversalTime();
                                    du.Datetime = dataTime.ToUniversalTime();
                                }
                                else
                                {
                                    Console.WriteLine("数据时间错误，无法转换成数据时间!");
                                }

                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine($"时间标记不正确,{du==null}{ex.Message}");
                                du.Datetime = DateTime.Now.ToUniversalTime();
                            }
                            break;
                        case -1:
                        case -3://Tag标记
                            du.tags.Add("EquipCode", item.Value.ToString().Trim());
                            break;
                        default:
                            break;
                    }
                    if (item.Value != null)
                    {
                        dc.pKey = item.PCode;
                        dc.pValue = item.Value;
                        dc.Cycle = item.Cycle;
                        dc.IsTecParam = item.IsTecParam;
                        dc.CollectionAddress = item.CollectionAddress;
                        dc.Address = item.Address;
                        du.listCells.Add(dc);
                    }
                }
                if (!du.tags.ContainsKey("EquipCode"))
                {
                    du.tags.Add("EquipCode", "T-1203");
                }
                if (du.Datetime == default(DateTime))
                {
                    du.Datetime = DateTime.Now.ToUniversalTime();
                }
                du.MeasurementName = "T_B";
                return du;
            }
            else
            {
                return null;
            }
        }

    }
}
