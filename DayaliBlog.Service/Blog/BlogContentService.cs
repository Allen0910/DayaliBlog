using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using Dapper;
using DayaliBlog.Model.Blog;
using DayaliBlog.Service.Sys;

namespace DayaliBlog.Service.Blog
{
    public class BlogContentService
    {
        /// <summary>
        /// 添加博客
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Insert(T_BLOG_CONTENT model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into T_BLOG_CONTENT(");
            strSql.Append("BlogID,BlogTitle,BlogContent,BlogType,BlogState,LastUptTime,CreateUser,CreateTIme,UpdateUser,UpdateTIme,Remark)");

            strSql.Append(" values (");
            strSql.Append("@BlogID,@BlogTitle,@BlogContent,@BlogType,@BlogState,@LastUptTime,@CreateUser,@CreateTIme,@UpdateUser,@UpdateTIme,@Remark)");
            strSql.Append("; SELECT @@IDENTITY ;");
            using (var conn=ConnentionFactory.GetOpenSqlConnection())
            {
                int contentId=conn.Query<int>(strSql.ToString(),model).First();
                return contentId;
            }
        }

        public int Insert(T_BLOG_CONTENT model,IDbTransaction transaction)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into T_BLOG_CONTENT(");
            strSql.Append("BlogID,BlogTitle,BlogContent,BlogType,BlogState,LastUptTime,CreateUser,CreateTIme,UpdateUser,UpdateTIme,Remark)");

            strSql.Append(" values (");
            strSql.Append("@BlogID,@BlogTitle,@BlogContent,@BlogType,@BlogState,@LastUptTime,@CreateUser,@CreateTIme,@UpdateUser,@UpdateTIme,@Remark)");
            strSql.Append("; SELECT @@IDENTITY ;");
            using (var conn = ConnentionFactory.GetOpenSqlConnection())
            {
                int contentId = conn.Query<int>(strSql.ToString(), model, transaction).First();
                return contentId;
            }
        }

        /// <summary>
        /// 修改博客内容
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Update(T_BLOG_CONTENT model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update T_BLOG_CONTENT set ");
            strSql.Append("BlogTitle=@BlogTitle,");
            strSql.Append("BlogContent=@BlogContent,");
            strSql.Append("BlogType=@BlogType,");
            strSql.Append("BlogState=@BlogState,");
            strSql.Append("LastUptTime=@LastUptTime,");
            strSql.Append("CreateUser=@CreateUser,");
            strSql.Append("CreateTIme=@CreateTIme,");
            strSql.Append("UpdateUser=@UpdateUser,");
            strSql.Append("UpdateTIme=@UpdateTIme,");
            strSql.Append("Remark=@Remark");
            strSql.Append("where BlogID=@BlogID");
            using (var conn=ConnentionFactory.GetOpenSqlConnection())
            {
                int resId = conn.Execute(strSql.ToString(), model);
                return resId > 0;
            }
        }

        /// <summary>
        /// 获取博客列表
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public List<T_BLOG_CONTENT> GetList(string where)
        {
            string strSql = "select BlogID,BlogTitle,BlogContent,BlogType,BlogState,LastUptTime,CreateUser,CreateTIme,UpdateUser,UpdateTIme,Remark ";
            if (!string.IsNullOrEmpty(where))
            {
                strSql += "where " + where;
            }
            using (var conn=ConnentionFactory.GetOpenSqlConnection())
            {
                var list = conn.Query<T_BLOG_CONTENT>(strSql).ToList();
                return list;
            }
        }

        /// <summary>
        /// 删除博客
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Delete(int id)
        {
            string strSql = "delete from T_BLOG_CONTENT where BlogID=@id";
            using (var conn=ConnentionFactory.GetOpenSqlConnection())
            {
                int resId = conn.Execute(strSql, new {id});
                return resId > 0;
            }
        }
    }
}
