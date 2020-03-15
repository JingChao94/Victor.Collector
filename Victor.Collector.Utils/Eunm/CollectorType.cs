using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Victor.Collector.Utils.Eunm
{
    /// <summary>
    /// 采集类型
    /// </summary>
    public enum CollectorType
    {
        TestCode,
        Socket,
        Http,
        OpcDA,
        OpcUA,
        ModbusTcp,
        ModbusUdp,
        ModbusRtu
    }
}
