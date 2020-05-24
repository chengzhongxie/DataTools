using Common.Enum;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Helper
{
    /// <summary>
    /// 数据链接
    /// </summary>
    public class SqlHelper
    {
        private readonly string ip;// 数据库地址
        private readonly string uid;// 用户名
        private readonly string pwd;// 密码
        private readonly string database;// 库
        private readonly string sqlClass;// 数据库类型

        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="ip">数据库地址</param>
        /// <param name="uid">用户名</param>
        /// <param name="pwd">密码</param>
        /// <param name="database">库</param>
        /// <param name="sqlClass">数据库类型</param>
        public SqlHelper(string ip, string uid, string pwd, string database, string sqlClass)
        {
            System.Collections.Generic.Dictionary<string, string> valuePairs = null;
            // 非空判断
            if (string.IsNullOrWhiteSpace(ip) || string.IsNullOrWhiteSpace(uid) || string.IsNullOrWhiteSpace(pwd) || string.IsNullOrWhiteSpace(database) || string.IsNullOrWhiteSpace(sqlClass))
            {
                valuePairs = new Dictionary<string, string>();
                valuePairs.Add(nameof(ip), ip);
                valuePairs.Add(nameof(uid), uid);
                valuePairs.Add(nameof(pwd), pwd);
                valuePairs.Add(nameof(database), database);
                valuePairs.Add(nameof(sqlClass), sqlClass);
                Utilities.LogUtilities.IsNullErrorLog(valuePairs);
            }
            this.ip = ip;
            this.uid = uid;
            this.pwd = pwd;
            this.database = database;
            this.sqlClass = sqlClass;
        }

        /// <summary>
        /// 测试连接
        /// </summary>
        /// <returns></returns>
        public bool SqlTestLink()
        {
            if (sqlClass == SqlEnum.SqlServer)
            {
                SqlServerHelper sqlServer = new SqlServerHelper(ip, uid, pwd, database);
                return sqlServer.ConnectionTest();
            }
            else if (sqlClass == SqlEnum.Mysql)
            {
                MySqlHelper mySql = new MySqlHelper(ip, uid, pwd, database);
                return mySql.TestLink();
            }
            else if (sqlClass == SqlEnum.Oracle)
            {
                OracleHelper oracle = new OracleHelper(ip, uid, pwd, database);
                return oracle.CheckConnection();
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 获取结果集
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public DataTable GetDataTable(string sql)
        {
            System.Collections.Generic.Dictionary<string, string> valuePairs = null;
            // 非空判断
            if (string.IsNullOrWhiteSpace(sql))
            {
                valuePairs = new Dictionary<string, string>();
                valuePairs.Add(nameof(sql), sql);
                Utilities.LogUtilities.IsNullErrorLog(valuePairs);
            }
            if (sqlClass == SqlEnum.SqlServer)
            {
                SqlServerHelper sqlServer = new SqlServerHelper(ip, uid, pwd, database);
                return sqlServer.ExecuteTable(sql);
            }
            else if (sqlClass == SqlEnum.Mysql)
            {
                MySqlHelper mySql = new MySqlHelper(ip, uid, pwd, database);
                return mySql.ExecuteDataTable(sql);
            }
            else if (sqlClass == SqlEnum.Oracle)
            {
                OracleHelper oracle = new OracleHelper(ip, uid, pwd, database);
                return oracle.ExecToSqlGetTable(sql);
            }
            else
            {
                return new DataTable();
            }

        }
    }
}
