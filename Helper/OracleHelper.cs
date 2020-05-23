using System;
using System.Collections.Generic;
using System.Text;
using System.Data.OracleClient;
using System.Data;

namespace Helper
{
    public class OracleHelper
    {
        //标准链接
        private readonly string strConn = string.Empty;

        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="ip">数据库地址</param>
        /// <param name="uid">用户名</param>
        /// <param name="pwd">密码</param>
        /// <param name="database">库</param>
        public OracleHelper(string ip, string uid, string pwd, string database)
        {
            Dictionary<string, string> valuePairs = null;
            // 非空判断
            if (string.IsNullOrWhiteSpace(ip) || string.IsNullOrWhiteSpace(uid) || string.IsNullOrWhiteSpace(pwd) || string.IsNullOrWhiteSpace(database))
            {
                valuePairs = new Dictionary<string, string>();
                valuePairs.Add("ip", ip);
                valuePairs.Add("uid", uid);
                valuePairs.Add("pwd", pwd);
                valuePairs.Add("database", database);
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
                port = "1521";
            }
            strConn = $"Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST={ips})(PORT={port})))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME={database})));User Id={uid};Password={pwd};";
        }

        /// <summary>
        /// 执行存储过程获取带有Out的参数
        /// </summary>
        /// <param name="cmdText">存储过程名称</param>
        /// <param name="outParameters">输出的参数名</param>
        /// <param name="oracleParameters">所传参数（必须按照存储过程参数顺序）</param>
        /// <param name="strConn">链接字符串</param>
        /// <returns></returns>
        public static string ExecToStoredProcedureGetString(string cmdText, string outParameters, OracleParameter[] oracleParameters, string strConn)
        {
            using (OracleConnection conn = new OracleConnection(strConn))
            {
                //OracleParameter[] SqlParameters = {

                //    new OracleParameter("ZYH", OracleDbType.Varchar2,"",ParameterDirection.Input),
                //    new OracleParameter("YJJE", OracleDbType.Varchar2,100,"", ParameterDirection.Output)
                //};
                OracleCommand cmd = new OracleCommand(cmdText, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddRange(oracleParameters);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                return cmd.Parameters[outParameters].Value.ToString();
            }
        }

        /// <summary>
        /// 执行存储过程获取带有Out的游标数据集
        /// </summary>
        /// <param name="cmdText">存储过程名称</param>
        /// <param name="outParameters">输出的游标名</param>
        /// <param name="oracleParameters">所传参数（必须按照存储过程参数顺序）</param>
        /// <param name="strConn">链接字符串</param>
        /// <returns></returns>
        public static DataTable ExecToStoredProcedureGetTable(string storedProcedName, OracleParameter[] oracleParameters, string strConn)
        {
            using (OracleConnection conn = new OracleConnection(strConn))
            {
                OracleCommand cmd = new OracleCommand(storedProcedName, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddRange(oracleParameters);
                OracleDataAdapter oda = new OracleDataAdapter(cmd);
                conn.Open();
                DataSet ds = new DataSet();
                oda.Fill(ds);
                conn.Close();
                return ds.Tables[0];
            }
        }

        /// <summary>
        /// 执行存储过程没有返回值
        /// </summary>
        /// <param name="cmdText">存储过程名称</param>
        /// <param name="outParameters">参数</param>
        /// <param name="oracleParameters">所传参数（必须按照存储过程参数顺序）</param>
        /// <param name="strConn">链接字符串</param>
        /// <returns></returns>
        public static void ExecToStoredProcedure(string cmdText, OracleParameter[] oracleParameters, string strConn)
        {
            using (OracleConnection conn = new OracleConnection(strConn))
            {
                OracleCommand cmd = new OracleCommand(cmdText, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddRange(oracleParameters);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }

        /// <summary>
        /// 执行sql获取数据集
        /// </summary>
        /// <param name="cmdText">sql语句</param>
        /// <param name="oracleParameters">所传参数（必须按照存储过程参数顺序）</param>
        /// <param name="strConn">链接字符串</param>
        /// <returns></returns>
        public static DataTable ExecToSqlGetTable(string cmdText, OracleParameter[] oracleParameters, string strConn)
        {
            using (OracleConnection conn = new OracleConnection(strConn))
            {
                OracleCommand cmd = new OracleCommand(cmdText, conn);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddRange(oracleParameters);
                OracleDataAdapter oda = new OracleDataAdapter(cmd);
                conn.Open();
                DataSet ds = new DataSet();
                oda.Fill(ds);
                conn.Close();
                return ds.Tables[0];
            }
        }

        /// <summary>
        /// 执行sql获取数据集
        /// </summary>
        /// <param name="cmdText">sql语句</param>
        /// <param name="oracleParameters">所传参数（必须按照存储过程参数顺序）</param>
        /// <param name="strConn">链接字符串</param>
        /// <returns></returns>
        public static DataTable ExecToSqlGetTable(string cmdText, string strConn)
        {
            using (OracleConnection conn = new OracleConnection(strConn))
            {
                OracleCommand cmd = new OracleCommand(cmdText, conn);
                cmd.CommandType = CommandType.Text;
                OracleDataAdapter oda = new OracleDataAdapter(cmd);
                conn.Open();
                DataSet ds = new DataSet();
                oda.Fill(ds);
                conn.Close();
                return ds.Tables[0];
            }
        }

        /// <summary>
        /// 执行sql执行增删改
        /// </summary>
        /// <param name="cmdText">sql语句</param>
        /// <param name="oracleParameters">所传参数（必须按照存储过程参数顺序）</param>
        /// <param name="strConn">链接字符串</param>
        /// <returns></returns>
        public static int ExecToSqlNonQuery(string cmdText, OracleParameter[] oracleParameters, string strConn)
        {
            using (OracleConnection conn = new OracleConnection(strConn))
            {
                OracleCommand cmd = new OracleCommand(cmdText, conn);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddRange(oracleParameters);
                conn.Open();
                int result = cmd.ExecuteNonQuery();
                conn.Close();
                return result;
            }
        }
        /// <summary>
        /// 执行sql执行增删改
        /// </summary>
        /// <param name="cmdText">sql语句</param>
        /// <param name="oracleParameters">所传参数（必须按照存储过程参数顺序）</param>
        /// <param name="strConn">链接字符串</param>
        /// <returns></returns>
        public static int ExecToSqlNonQuery(string cmdText, string strConn)
        {
            using (OracleConnection conn = new OracleConnection(strConn))
            {
                OracleCommand cmd = new OracleCommand(cmdText, conn);
                cmd.CommandType = CommandType.Text;
                conn.Open();
                int result = cmd.ExecuteNonQuery();
                conn.Close();
                return result;
            }
        }


        /// <summary>
        /// 执行多条Sql获取返回值
        /// </summary>
        /// <param name="listSelectSql"></param>
        /// <returns></returns>
        //public DataSet Query(List<string> listSelectSql, string strConn)
        //{
        //    using (OracleConnection conn = new OracleConnection(strConn))
        //    {
        //        OracleCommand cmd = new OracleCommand();
        //        StringBuilder strSql = new StringBuilder();
        //        strSql.Append("begin ");
        //        for (int i = 0; i < listSelectSql.Count; i++)
        //        {
        //            string paraName = "p_cursor_" + i;
        //            strSql.AppendFormat("open :{0} for {1}; ", paraName, listSelectSql[i]);
        //            cmd.Parameters.Add(paraName, OracleDbType.RefCursor, DBNull.Value, ParameterDirection.Output);
        //        }
        //        strSql.Append("end;");
        //        cmd.Connection = conn;
        //        cmd.CommandText = strSql.ToString();
        //        OracleDataAdapter oda = new OracleDataAdapter();
        //        oda.SelectCommand = cmd;
        //        conn.Open();
        //        DataSet ds = new DataSet();
        //        oda.Fill(ds);
        //        conn.Close();
        //        return ds;
        //    }
        //}
        /// <summary>
        /// 测试连接
        /// </summary>
        /// <returns></returns>
        public bool CheckConnection()
        {
            try
            {
                OracleConnection OraConn = new OracleConnection(strConn);
                OraConn.Open();
                OraConn.Close();
                return true;
            }
            catch (System.Exception e)
            {
                return false;

            }
        }
    }
}
