using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Dto
{
    /// <summary>
    /// 数据用户信息
    /// </summary>
    public class SqlUserDto
    {
        /// <summary>
        /// 链接地址
        /// </summary>
        public string Server { get; set; }
        /// <summary>
        /// 用户名
        /// </summary>
        public string Uid { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        public string Pwd { get; set; }
        /// <summary>
        /// 数据名
        /// </summary>
        public string DataBase { get; set; }
        /// <summary>
        /// 数据库类型
        /// </summary>
        public string DatabaseType { get; set; }

    }
}
