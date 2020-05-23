using System;
using System.Data;
using System.Data.SqlClient;

namespace Helper
{
    /// <summary>
    /// Sql Server
    /// </summary>
    public class SqlHelper
    {
        private readonly string constr = string.Empty;

        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="ip">数据库地址</param>
        /// <param name="uid">用户名</param>
        /// <param name="pwd">密码</param>
        /// <param name="database">库</param>
        public SqlHelper(string ip, string uid, string pwd,string database)
        {
            System.Collections.Generic.Dictionary<string, string> valuePairs = null;
            // 非空判断
            if (string.IsNullOrWhiteSpace(ip) || string.IsNullOrWhiteSpace(uid) || string.IsNullOrWhiteSpace(pwd) || string.IsNullOrWhiteSpace(database))
            {
                valuePairs = new System.Collections.Generic.Dictionary<string, string>();
                valuePairs.Add("ip", ip);
                valuePairs.Add("uid", uid);
                valuePairs.Add("pwd", pwd);
                valuePairs.Add("database", database);
                Utilities.LogUtilities.IsNullErrorLog(valuePairs);
            }
            constr = $"server={ip};uid={uid};pwd={pwd};database={database};Integrated Security=SSPI; Connection Timeout=10";
        }

        /// <summary>
        /// 数据表的增、删、改；
        /// </summary>
        /// <param name="conn"></param>
        /// <param name="sql"></param>
        /// <param name="sp"></param>
        /// <returns></returns>
        public int ExecuteNonQuery(string sql, params SqlParameter[] sp)
        {
            using (SqlConnection con = new SqlConnection(constr))
            {

                return ExecuteNonQuery(con, sql, sp);
            }

        }

        private int ExecuteNonQuery(SqlConnection conn, string sql, params SqlParameter[] ps)
        {
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                conn.Open();
                cmd.Parameters.AddRange(ps);
                return cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// 执行一条返回第一条记录第一列的SqlCommand命令，通过专用的连接字符串。
        /// 使用参数数组提供参数
        /// </summary>
        /// <param name="conn"></param>
        /// <param name="sql"></param>
        /// <param name="ps"></param>
        /// <returns>返回一个object数据</returns>
        public object ExecuteScale(SqlConnection conn, string sql, params SqlParameter[] ps)
        {
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                conn.Open();
                cmd.Parameters.AddRange(ps);
                return cmd.ExecuteScalar();
            }

        }

        /// <summary>
        /// 执行一条返回第一条记录第一列的SqlCommand命令，通过专用的连接字符串。
        /// 使用参数数组提供参数
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <param name="ps">参数</param>
        /// <returns>返回一个object数据</returns>
        public object ExecuteScale(string sql, params SqlParameter[] ps)
        {
            using (SqlConnection conn = new SqlConnection(constr))
            {
                return ExecuteScale(conn, sql, ps);
            }
        }

        /// <summary>
        /// 该方法用于读取数据
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <param name="sp">sql参数</param>
        /// <returns>SqlDataReader类型</returns>
        public SqlDataReader ExecuteReader(string sql, params SqlParameter[] sp)
        {
            SqlConnection conn = new SqlConnection(constr);
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddRange(sp);
                try
                {

                    conn.Open();
                    return cmd.ExecuteReader(CommandBehavior.CloseConnection);
                }
                catch (Exception ex)
                {

                    conn.Close();
                    conn.Dispose();
                    throw ex;

                }

            }
        }

        /// <summary>
        /// 读取数据返回的是datatable
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="ps"></param>
        /// <returns>DataTable</returns>
        public DataTable ExecuteTable(string sql, params SqlParameter[] ps)
        {
            DataTable dt = new DataTable();
            using (SqlDataAdapter da = new SqlDataAdapter(sql, constr))
            {
                if (ps != null)
                {
                    da.SelectCommand.Parameters.AddRange(ps);
                }
                da.Fill(dt);

            }
            return dt;
        }

        /// <summary>
        /// 测试连接数据库是否成功
        /// </summary>
        /// <returns></returns>
        public bool ConnectionTest()
        {
            bool IsCanConnectioned = false;
            //创建连接对象
            SqlConnection mySqlConnection = new SqlConnection(constr);
            //ConnectionTimeout 在.net 1.x 可以设置 在.net 2.0后是只读属性，则需要在连接字符串设置
            //如：server=.;uid=sa;pwd=;database=PMIS;Integrated Security=SSPI; Connection Timeout=30
            //mySqlConnection.ConnectionTimeout = 1;//设置连接超时的时间
            try
            {
                //Open DataBase
                //打开数据库
                mySqlConnection.Open();
                IsCanConnectioned = true;
            }
            catch
            {
                //Can not Open DataBase
                //打开不成功 则连接不成功
                IsCanConnectioned = false;
            }
            finally
            {
                //Close DataBase
                //关闭数据库连接
                mySqlConnection.Close();
            }
            //mySqlConnection   is   a   SqlConnection   object 
            if (mySqlConnection.State == ConnectionState.Closed || mySqlConnection.State == ConnectionState.Broken)
            {
                //Connection   is   not   available  
                return IsCanConnectioned;
            }
            else
            {
                //Connection   is   available  
                return IsCanConnectioned;
            }
        }
    }
}
