using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace Utilities
{
    /// <summary>
    /// 基类
    /// </summary>
    public class Utilities
    {
        MethodBase method = new System.Diagnostics.StackTrace().GetFrame(0).GetMethod();
        /// <summary>
        /// 类名
        /// </summary>
        public string ClassName { get; set; }
        /// <summary>
        /// 方法名
        /// </summary>
        public string MethodName { get; set; }

        /// <summary>
        /// 类名+方法名
        /// </summary>
        public string ClassMethodName { get; set; }

        public Utilities()
        {
            // 类名
            ClassName = method.ReflectedType.FullName;
            // 方法名
            MethodName = method.Name;
            // 类名+方法名
            ClassMethodName = $"{ClassName}.{MethodName}";
        }
    }
}
