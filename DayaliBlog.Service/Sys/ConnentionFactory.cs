using MySql.Data.MySqlClient;
using System.Data.Common;
using System.Data.SqlClient;

namespace DayaliBlog.Service.Sys
{
    public class ConnentionFactory
    {
        /// <summary>
        /// 获取Sql Server数据库连接
        /// </summary>
        /// <returns></returns>
        public static DbConnection GetOpenSqlConnection()
        {
            var conn = new SqlConnection("server=.;uid=sa;pwd=spring;database=TestBlog");
            conn.Open();
            return conn;
        }
        /// <summary>
        /// 获取Sql Server数据库连接
        /// 传连接串
        /// </summary>
        /// <returns></returns>
        public static DbConnection GetOpenSqlConnection(string connstrings)
        {
            var conn = new SqlConnection(connstrings);
            //var conn = new MySqlConnection(connstrings);
            conn.Open();
            return conn;
        }
    }
}
