using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Dapper;
using DayaliBlog.Service.Sys;

namespace DayaliBlog.Service.Blog
{
    public class BlogCategRelService
    {
        public int Insert(int blogId, int categId,IDbTransaction transaction)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into T_BLOG_CATELOG_REL(");
            strSql.Append("BlogID,CatelogID)");

            strSql.Append(" values (");
            strSql.Append("@BlogID,@CatelogID)");
            using (var conn=ConnentionFactory.GetOpenSqlConnection())
            {
                return conn.Execute(strSql.ToString(), new {BlogID = blogId, CatelogID = categId}, transaction);
            }
        }
    }
}
