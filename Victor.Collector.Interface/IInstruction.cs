using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Victor.Collector.Utils.Eunm;

namespace Victor.Collector.Interface
{
    public interface IInstruction<T>
    {
        string Header { get; set; }
        CollectorLevel Level { get; set; }
        T Body { get; set; }
        string Date { get; set; }
        CollectorStatus Status { get; set; }
    }
}
