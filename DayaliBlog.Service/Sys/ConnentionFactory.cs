using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Text;

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
            var conn = new SqlConnection("server=.;uid=sa;pwd=666666;database=DayaliBlogDB");
            conn.Open();
            return conn;
        }
    }
}
