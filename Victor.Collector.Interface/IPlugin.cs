using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Victor.Collector.Interface
{
    public interface IPlugin
    {
        #region 基本属性
        int GetPluginId();
        string GetPluginName();
        #endregion

        #region 生成插件实例
        object InitPlugin();
        object InitPlugin(object[] paras);
        #endregion

        #region 释放资源
        bool DisposePlugin();
        #endregion



    }
}
