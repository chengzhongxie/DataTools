using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;
using System.Data;
using System.Data.SqlClient;
using Utilities;

namespace Helper
{
    /// <summary>
    /// My sql
    /// </summary>
    public class MySqlHelper
    {
        public string connstr = string.Empty;

        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="ip">数据库地址</param>
        /// <param name="uid">用户名</param>
        /// <param name="pwd">密码</param>
        /// <param name="database">库</param>
        public MySqlHelper(string ip, string uid, string pwd, string database)
        {
            Dictionary<string, string> valuePairs = null;
            // 非空判断
            if (string.IsNullOrWhiteSpace(ip) || string.IsNullOrWhiteSpace(uid) || string.IsNullOrWhiteSpace(pwd) || string.IsNullOrWhiteSpace(database))
            {
                valuePairs = new Dictionary<string, string>();
                valuePairs.Add(nameof(ip), ip);
                valuePairs.Add(nameof(uid), uid);
                valuePairs.Add(nameof(pwd), pwd);
                valuePairs.Add(nameof(database), database);
                Utilities.LogUtilities.IsNullErrorLog(valuePairs);
            }
            // 处理端口号
            string ips, port = string.Empty;
            if (ip.IndexOf(":") > 0)
            {
                string[] iplist = ip.Split(':');
                ips = iplist[0];
                port = iplist[1];
            }
            else
            {
                ips = ip;
                port = "3306";
            }
            connstr = $"server={ips};port={port};user={uid};password={pwd}; database={database};SslMode=None;Allow User Variables=True;Charset=utf8;";
        }


        /// <summary>
        /// 封装一个执行的sql 返回受影响的行数
        /// </summary>
        /// <param name="sqlText"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public int ExecuteNonQuery(string sqlText, params MySqlParameter[] parameters)
        {
            using (MySqlConnection conn = new MySqlConnection(connstr))
            {
                using (MySqlCommand cmd = conn.CreateCommand())
                {
                    conn.Open();
                    cmd.CommandText = sqlText;
                    cmd.Parameters.AddRange(parameters);
                    return cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// 执行sql,返回查询结果中的第一行第一列的值
        /// </summary>
        /// <param name="sqlText"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public object ExecuteScalar(string sqlText, params MySqlParameter[] parameters)
        {
            using (MySqlConnection conn = new MySqlConnection(connstr))
            {
                using (MySqlCommand cmd = conn.CreateCommand())
                {
                    conn.Open();
                    cmd.CommandText = sqlText;
                    cmd.Parameters.AddRange(parameters);
                    return cmd.ExecuteScalar();
                }
            }
        }

        /// <summary>
        /// 执行sql 返回一个DataTable
        /// </summary>
        /// <param name="sqlText"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public System.Data.DataTable ExecuteDataTable(string sqlText, params MySqlParameter[] parameters)
        {
            using (MySqlDataAdapter adapter = new MySqlDataAdapter(sqlText, connstr))
            {
                DataTable dt = new DataTable();
                if (parameters != null)
                {
                    adapter.SelectCommand.Parameters.AddRange(parameters);
                }
                adapter.Fill(dt);
                return dt;
            }
        }

        /// <summary>
        /// 执行sql脚本
        /// </summary>
        /// <param name="sqlText"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public MySqlDataReader ExecuteReader(string sqlText, params MySqlParameter[] parameters)
        {
            MySqlConnection conn = new MySqlConnection(connstr);
            MySqlCommand cmd = conn.CreateCommand();
            conn.Open();
            cmd.CommandText = sqlText;
            if (parameters != null)
            {
                cmd.Parameters.AddRange(parameters);
            }
            return cmd.ExecuteReader(CommandBehavior.CloseConnection);
        }

        /// <summary>
        /// 测试连接
        /// </summary>
        /// <returns></returns>
        public bool TestLink()
        {
            try
            {
                MySqlConnection conn = new MySqlConnection(connstr);
                conn.Open();
                conn.Close();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
