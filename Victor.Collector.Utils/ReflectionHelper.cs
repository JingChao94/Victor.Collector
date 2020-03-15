using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Victor.Collector.Utils
{  
    /// <summary>
    /// 反射帮助类
    /// </summary>
    public static class ReflectionHelper
    {
        private static string interfaceName="IPlugin";

        /// <summary>
        /// 创建对象实例
        /// </summry>
        /// <typeparam name="T"></typeparam>
        /// <param name="fullName">命名空间.类型名</param>
        /// <param name="assemblyName">程序集</param>
        /// <returns></returns>
        public static T CreateInstance<T>(string fullName, string assemblyName)
        {
            string path = fullName + "," + assemblyName;//命名空间.类型名,程序集
            Type o = Type.GetType(path);//加载类型
            object obj = Activator.CreateInstance(o, true);//根据类型创建实例
            return (T)obj;//类型转换并返回
        }

        /// <summary>
        /// 创建对象实例
        /// </summary>
        /// <typeparam name="T">要创建对象的类型</typeparam>
        /// <param name="assemblyName">类型所在程序集名称</param>
        /// <param name="nameSpace">类型所在命名空间</param>
        /// <param name="className">类型名</param>
        /// <returns></returns>
        public static T CreateInstance<T>(string assemblyName, string nameSpace, string className)
        {
            try
            {
                string fullName = nameSpace + "." + className;//命名空间.类型名
                                                              //此为第一种写法
                object ect = Assembly.Load(assemblyName).CreateInstance(fullName);//加载程序集，创建程序集里面的 命名空间.类型名 实例
                return (T)ect;//类型转换并返回
                              //下面是第二种写法
                              //string path = fullName + "," + assemblyName;//命名空间.类型名,程序集
                              //Type o = Type.GetType(path);//加载类型
                              //object obj = Activator.CreateInstance(o, true);//根据类型创建实例
                              //return (T)obj;//类型转换并返回
            }
            catch
            {
                //发生异常，返回类型的默认值
                return default(T);
            }
        }

        /// <summary>
        /// 通过Type加载对象
        /// </summary>
        /// <typeparam name="T">要创建对象的类型</typeparam>
        /// <param name="type">识别到的Type</param>
        /// <returns>创建的对象</returns>
        public static T InitClassByType<T>(Type type)
        {
            return (T)type.Assembly.CreateInstance(type.FullName);
        }

        /// <summary>
        /// 返回指定路径下的可加载插件对象数组
        /// </summary>
        /// <param name="documentPath">指定的路径></param>
        /// <returns>dll文件对象集合</returns>
        public static Type[] LoadDocument(string documentPath)
        {
            if (Directory.Exists(documentPath) == false)
            {
                return null;
            }
            var members = new List<Type>();
            //找到目录下的dll文件
            String[] files = Directory.GetFiles(documentPath, @"*.dll");
            if (files.GetLength(0) > 0)
            {
                for (int i = 0; i < files.GetLength(0); i++)
                {
                    Type[] cs = LoadFiles(files[i]);
                    if (cs != null && cs.Length > 0)
                    {
                        members.AddRange(cs);
                    }
                }
            }
            return members.ToArray();
        }

        /// <summary>
        /// 返回指定路径的dll文件对象中包含的多个类对象
        /// </summary>
        /// <param name="filePath">指定的dll绝对路径</param>
        /// <returns>符合条件的类对象</returns>
        public static Type[] LoadFiles(string filePath)
        {
            if (File.Exists(filePath) == false)
            {
                return null;
            }
            var asm = Assembly.LoadFrom(filePath);
            return asm.GetTypes().Where(t => t.GetInterface(interfaceName) != null).ToArray();
        }
    }


}
