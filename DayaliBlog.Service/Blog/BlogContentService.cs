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
            strSql.Append("BlogTitle,BlogContent,BlogType,BlogState,LastUptTime,CreateUser,CreateTIme,Remark)");

            strSql.Append(" values (");
            strSql.Append("@BlogTitle,@BlogContent,@BlogType,@BlogState,@LastUptTime,@CreateUser,@CreateTIme,@Remark)");
            strSql.Append("; SELECT @@IDENTITY ;");
            using (var conn=ConnentionFactory.GetOpenSqlConnection())
            {
                int contentBlogID=conn.Query<int>(strSql.ToString(),model).First();
                return contentBlogID;
            }
        }

        public int Insert(T_BLOG_CONTENT model,IDbTransaction transaction)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into T_BLOG_CONTENT(");
            strSql.Append("BlogTitle,BlogContent,BlogType,BlogState,LastUptTime,CreateUser,CreateTIme,UpdateUser,UpdateTIme,Remark)");

            strSql.Append(" values (");
            strSql.Append("@BlogTitle,@BlogContent,@BlogType,@BlogState,@LastUptTime,@CreateUser,@CreateTIme,@UpdateUser,@UpdateTIme,@Remark)");
            strSql.Append("; SELECT @@IDENTITY ;");
            using (var conn = ConnentionFactory.GetOpenSqlConnection())
            {
                int contentBlogID = conn.Query<int>(strSql.ToString(), model, transaction).First();
                return contentBlogID;
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
            strSql.Append("UpdateUser=@UpdateUser,");
            strSql.Append("UpdateTIme=@UpdateTIme,");
            strSql.Append("Remark=@Remark");
            strSql.Append(" where BlogID=@BlogID");
            using (var conn=ConnentionFactory.GetOpenSqlConnection())
            {
                int resBlogID = conn.Execute(strSql.ToString(), model);
                return resBlogID > 0;
            }
        }

        /// <summary>
        /// 获取博客列表
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public List<T_BLOG_CONTENT> GetList(string where)
        {
            string strSql = "select b.BlogID,g.CatelogID,g.CatelogName,BlogTitle,BlogContent,BlogType,c.SUB_NM as BlogTypeName,BlogState,LastUptTime,b.CreateUser,b.CreateTIme,b.UpdateUser,b.UpdateTIme,b.Remark from T_BLOG_CONTENT b";
            strSql += " inner join T_BLOG_CATELOG_REL r on r.BlogID=b.BlogID ";
            strSql += " inner join T_BLOG_CATELOG g on g.CatelogID=r.CatelogID ";
            strSql += " inner join T_SYS_CONFIG c on c.ID=2 and c.SUB_ID=b.BlogType";
            if (!string.IsNullOrEmpty(where))
            {
                strSql += " where " + where;
            }
            strSql += " order by LastUptTime desc";
            using (var conn=ConnentionFactory.GetOpenSqlConnection())
            {
                var list = conn.Query<T_BLOG_CONTENT>(strSql).ToList();
                return list;
            }
        }

        public T_BLOG_CONTENT GetModel(string where)
        {
            var src = GetList(where);
            return src != null ? src.First() : null;
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
                int resBlogID = conn.Execute(strSql, new {id});
                return resBlogID > 0;
            }
        }
    }
}
