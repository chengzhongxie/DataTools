using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Utilities
{
    /// <summary>
    /// 记录日志
    /// </summary>
    public static class LogUtilities
    {
        #region 存储日志
        /// <summary>
        /// 错误日志
        /// </summary>
        /// <param name="message">错误日志</param>
        public static void Error(string message)
        {
            log4net.ILog log = log4net.LogManager.GetLogger("Error");
            if (log.IsInfoEnabled)
            {
                log.Error(message);
            }
            log = null;
        }
        /// <summary>
        /// 普通日志
        /// </summary>
        /// <param name="message">日志内容</param>
        public static void Info(string message)
        {
            log4net.ILog log = log4net.LogManager.GetLogger("InfoLog");
            if (log.IsInfoEnabled)
            {
                log.Info(message);
            }
            log = null;
        }
        #endregion

        /// <summary>
        /// 记录空字段日志
        /// </summary>
        /// <param name="valuePairs">key:字段名 value:数据</param>
        public static void IsNullErrorLog(Dictionary<string, string> valuePairs)
        {
            StringBuilder sbValue = new StringBuilder();
            foreach (var item in valuePairs)
            {
                sbValue.Append($"{item.Key}:[{item.Value}]");
            }
            throw new ArgumentException(sbValue.ToString(), "字段为空数据");
        }
        /// <summary>
        /// 记录字段格式错误
        /// </summary>
        /// <param name="valuePairs">key:字段名 value:数据</param>
        public static void FormatErrorLog(Dictionary<string, string> valuePairs)
        {
            StringBuilder sbValue = new StringBuilder();
            foreach (var item in valuePairs)
            {
                sbValue.Append($"{item.Key}:[{item.Value}]");
            }
            throw new FormatException(sbValue.ToString());
        }
    }
}
