using System;
using System.Collections.Generic;
using System.Text;

namespace Benchmark_Test
{
    public class ParamBase : ICloneable
    {

        /// <summary>
        /// 参数ID
        /// </summary>
        public long? ID { get; set; }

        /// <summary>
        /// 参数Code
        /// </summary>
        public string PCode { get; set; }


        /// <summary>
        /// 所属设备类型ID
        /// </summary>
        public long Eq_TypeID { get; set; }

        /// <summary>
        /// 采集方式 1.PLC 2.Socket 3.DB 4.File 5.WebService
        /// </summary>
        public string PCtype { get; set; }

        /// <summary>
        /// 是否是固定参数
        /// </summary>
        public bool IsDefault { get; set; }


        /// <summary>
        /// 默认值
        /// </summary>
        public string PValue { get; set; }

        /// <summary>
        /// 参数名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 数据类型
        /// </summary>
        public string DataType { get; set; }

        /// <summary>
        /// 采集时间
        /// </summary>
        public long TimeStamp { get; set; }

        /// <summary>
        /// 采集值
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// byte[] 值
        /// </summary>
        public byte[] ParamBytes { get; set; }

        /// <summary>
        /// 采集频率 单位秒
        /// </summary>
        public int Cycle { get; set; } = 10;

        /// <summary>
        /// 采集区域  上位机代表命令 PLC为寄存器区域 数据库为表名
        /// </summary>
        public string Area
        {
            get
            {

                string[] address = this.Address.Split('.');
                return address[0];
            }
        }
        /// <summary>
        /// 解析后的采集地址
        /// </summary>
        public string CollectionAddress
        {
            get
            {
                if (Address.Contains("."))
                {
                    return Address.Split('.')[1];
                }
                else
                {
                    return string.Empty;
                }
            }
        }


        /// <summary>
        /// 采集地址
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// PLC地址
        /// </summary>
        public int PLCAddress
        {
            get
            {
                try
                {
                    if (Address.Contains("."))
                    {
                        if (Area == "W" || Area == "X" || Area == "Y" || Area == "B")
                        {
                            //return CommonHelper.HexToDec(Address.Split('.')[1]);
                            return int.Parse(Address.Split('.')[1]);
                        }
                        else if (Area.Length == 2 && Area.EndsWith("X") && int.Parse(Address.Split('.')[1]) > -1)
                        {
                            return int.Parse(Address.Split('.')[1]) - 1;
                        }
                        else
                        {
                            return int.Parse(Address.Split('.')[1]);
                        }
                    }
                    else
                    {
                        return 0;
                    }
                }
                catch (Exception ex)
                {
                    return 0;
                }
            }
        }

        /// <summary>
        /// 是否工艺参数
        /// </summary>
        public bool IsTecParam { get; set; }

        /// <summary>
        /// 最后一次采集时间
        /// </summary>
        public long LastTime { get; set; }

        /// <summary>
        /// 说明
        /// </summary>
        public string Note { get; set; }


        /// <summary>
        /// 插件方法
        /// </summary>
        public object actionPlug { get; set; }


        /// <summary>
        /// 读取长度
        /// </summary>
        public int? DataLength { get; set; }

        /// <summary>
        /// bit 偏移位
        /// </summary>

        /// <summary>
        /// bit 偏移位
        /// </summary>
        public int Sub
        {
            get
            {
                try
                {
                    if (Address.Contains("."))
                    {
                        if (Address.Split('.').Length == 3)
                        {
                            return int.Parse(Address.Split('.')[2]);
                        }
                        else
                        {
                            return 0;
                        }
                    }
                    else
                    {
                        return 0;
                    }
                }
                catch (Exception ex)
                {
                    return 0;
                }
            }
        }

        /// <summary>
        /// 是否为Bit变量
        /// </summary>
        public bool Isbit { get; set; } = false;

        /// <summary>
        /// 执行表达式
        /// </summary>
        public string ActionExpression { get; set; }


        /// <summary>
        /// 保留小数位
        /// </summary>
        public int Pos { get; set; }

        /// <summary>
        /// 采集缩放比例
        /// </summary>
        public double? Zoom { get; set; }

        public object Clone()
        {
            return base.MemberwiseClone();
        }
    }
}
