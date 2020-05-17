using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Dto
{
    /// <summary>
    /// 文件公共实体
    /// </summary>
    public class FileDto
    {
        /// <summary>
        /// 文件类型（json/xml）
        /// </summary>
        public string FileClass { get; set; }
        /// <summary>
        /// 获取文件选择类型（Json文件|*.json）
        /// </summary>
        public string Filter { get; set; }
        /// <summary>
        /// 获取文件选择类型后缀（.json）
        /// </summary>
        public string[] Extension { get; set; }
        /// <summary>
        /// 文件模式(Json转Excel)
        /// </summary>
        public string FileMode { get; set; }
    }
}
