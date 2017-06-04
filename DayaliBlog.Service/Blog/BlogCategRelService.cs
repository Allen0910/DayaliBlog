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
        public string ConnStr { get; set; }
        public int Insert(int BlogID, int categBlogID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into T_BLOG_CATELOG_REL(");
            strSql.Append("BlogID,CatelogID)");

            strSql.Append(" values (");
            strSql.Append("@BlogID,@CatelogID)");
            using (var conn = ConnentionFactory.GetOpenSqlConnection(ConnStr))
            {
                return conn.Execute(strSql.ToString(), new { BlogID = BlogID, CatelogID = categBlogID });
            }
        }
        public int Insert(int BlogID, int categBlogID,IDbTransaction transaction)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into T_BLOG_CATELOG_REL(");
            strSql.Append("BlogID,CatelogID)");

            strSql.Append(" values (");
            strSql.Append("@BlogID,@CatelogID)");
            using (var conn=ConnentionFactory.GetOpenSqlConnection(ConnStr))
            {
                return conn.Execute(strSql.ToString(), new {BlogID = BlogID, CatelogID = categBlogID}, transaction);
            }
        }

        public bool Delete(int BlogID)
        {
            string strSql = "delete from T_BLOG_CATELOG_REL where BlogID=@BlogID";
            using (var conn=ConnentionFactory.GetOpenSqlConnection(ConnStr))
            {
                int resBlogID = conn.Execute(strSql, new {BlogID = BlogID});
                return resBlogID > 0;
            }
        }
    }
}
