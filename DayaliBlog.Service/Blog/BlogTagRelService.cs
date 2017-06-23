using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Dapper;
using DayaliBlog.Service.Sys;

namespace DayaliBlog.Service.Blog
{
    public class BlogTagRelService
    {
        public string ConnStr;
        public BlogTagRelService(string conn)
        {
            ConnStr = conn;
        }
        public int Insert(int BlogID, int tagBlogID,IDbTransaction transaction)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into T_BLOG_TAG_REL(");
            strSql.Append("BlogID,TagID)");

            strSql.Append(" values (");
            strSql.Append("@BlogID,@TagID)");
            using (var conn=ConnentionFactory.GetOpenSqlConnection(ConnStr))
            {
                int resBlogID = conn.Execute(strSql.ToString(), new {BlogID = BlogID, TagID = tagBlogID}, transaction);
                return resBlogID;
            }
        }
    }
}
