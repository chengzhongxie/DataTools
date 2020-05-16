using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Enum
{
    /// <summary>
    /// 文件类型枚举
    /// </summary>
    public static class FileEnum
    {
        /// <summary>
        /// 文件夹
        /// </summary>
        public static string Folder { get { return "文件夹"; } }
        /// <summary>
        /// 文件
        /// </summary>
        public static string Files { get { return "文件"; } }
        /// <summary>
        /// json文件
        /// </summary>
        public static string JsonFiles { get { return "Json"; } }
        /// <summary>
        /// XML文件
        /// </summary>
        public static string XMLFiles { get { return "XML"; } }
        /// <summary>
        /// Json转Excel
        /// </summary>
        public static string JsonToExcel { get { return "Json转Excel"; } }
        /// <summary>
        /// XML转Excel
        /// </summary>
        public static string XMLToExcel { get { return "XML转Excel"; } }
    }
}
