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
        public int Insert(int blogId, int tagId,IDbTransaction transaction)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into T_BLOG_TAG_REL(");
            strSql.Append("BlogID,TagID)");

            strSql.Append(" values (");
            strSql.Append("@BlogID,@TagID)");
            using (var conn=ConnentionFactory.GetOpenSqlConnection())
            {
                int resId = conn.Execute(strSql.ToString(), new {BlogID = blogId, TagID = tagId}, transaction);
                return resId;
            }
        }
    }
}
