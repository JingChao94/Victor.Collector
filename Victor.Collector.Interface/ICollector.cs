using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Victor.Collector.Utils.Eunm;

namespace Victor.Collector.Interface
{
    public interface ICollector<T> : IPlugin
    {
        CollectorType GetCollectorType();
        bool Collect(IInstruction<T> instruction);
        IInstruction<T> Accept();
    }
}
