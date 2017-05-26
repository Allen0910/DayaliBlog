using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using Dapper;
using DayaliBlog.Model.Blog;
using DayaliBlog.Model.CustomModel;
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
            strSql.Append("BlogTitle,BlogCover,BlogContent,BlogType,BlogState,LastUptTime,CreateUser,CreateTIme,Remark)");

            strSql.Append(" values (");
            strSql.Append("@BlogTitle,@BlogCover,@BlogContent,@BlogType,@BlogState,@LastUptTime,@CreateUser,@CreateTIme,@Remark)");
            strSql.Append("; SELECT @@IDENTITY ;");
            using (var conn=ConnentionFactory.GetOpenSqlConnection())
            {
                var contentBlogId=conn.Query<int>(strSql.ToString(),model).First();
                return contentBlogId;
            }
        }

        public int Insert(T_BLOG_CONTENT model,IDbTransaction transaction)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into T_BLOG_CONTENT(");
            strSql.Append("BlogTitle,BlogCover,BlogContent,BlogType,BlogState,LastUptTime,CreateUser,CreateTIme,UpdateUser,UpdateTIme,Remark)");

            strSql.Append(" values (");
            strSql.Append("@BlogTitle,@BlogCover,@BlogContent,@BlogType,@BlogState,@LastUptTime,@CreateUser,@CreateTIme,@UpdateUser,@UpdateTIme,@Remark)");
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
            strSql.Append("BlogCover=@BlogCover,");
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
            string strSql = "select b.BlogID,g.CatelogID,g.CatelogName,BlogTitle,BlogCover,BlogContent,BlogType,c.SUB_NM as BlogTypeName,BlogState,LastUptTime,b.CreateUser,b.CreateTIme,b.UpdateUser,b.UpdateTIme,b.Remark from T_BLOG_CONTENT b";
            strSql += " inner join T_BLOG_CATELOG_REL r on r.BlogID=b.BlogID ";
            strSql += " inner join T_BLOG_CATELOG g on g.CatelogID=r.CatelogID ";
            strSql += " inner join T_SYS_CONFIG c on c.ID=2 and c.SUB_ID=b.BlogType";
            if (!string.IsNullOrEmpty(where))
            {
                strSql += " where " + where;
            }
            strSql += " order by b.BlogID desc";
            using (var conn=ConnentionFactory.GetOpenSqlConnection())
            {
                var list = conn.Query<T_BLOG_CONTENT>(strSql).ToList();
                return list;
            }
        }

        public List<BlogCategCount> GetCategCount(int userId)
        {
            string strSql = "SELECT r.CatelogID AS CatelogID,c.CatelogName,COUNT(1) AS BlogCount\r\nFROM dbo.T_BLOG_CONTENT b\r\nINNER JOIN dbo.T_BLOG_CATELOG_REL r ON r.BlogID = b.BlogID\r\nINNER JOIN dbo.T_BLOG_CATELOG c ON c.CatelogID = r.CatelogID\r\nWHERE b.CreateUser=" + userId + "\r\nGROUP BY r.CatelogID,c.CatelogName ORDER BY BlogCount DESC,CatelogID ASC";
            using (var conn = ConnentionFactory.GetOpenSqlConnection())
            {
                var list = conn.Query<BlogCategCount>(strSql).ToList();
                return list;
            }
        }

        public List<T_BLOG_CONTENT> GetListByPage(string orderBy,int pageSize,int pageIndex,string where)
        {
            if (!string.IsNullOrEmpty(where))
            {
                where = " where " + where;
            }
            if (string.IsNullOrEmpty(orderBy))
            {
                orderBy = " order by LastUptTime desc ";
            }
            string strSql = "select b.BlogID,g.CatelogID,g.CatelogName,BlogTitle,BlogCover,BlogContent,BlogType,c.SUB_NM as BlogTypeName,BlogState,LastUptTime,b.CreateUser,b.CreateTIme,b.UpdateUser,b.UpdateTIme,b.Remark from T_BLOG_CONTENT b";
            strSql += " inner join T_BLOG_CATELOG_REL r on r.BlogID=b.BlogID ";
            strSql += " inner join T_BLOG_CATELOG g on g.CatelogID=r.CatelogID ";
            strSql += " inner join T_SYS_CONFIG c on c.ID=2 and c.SUB_ID=b.BlogType ";
            string strFormat = string.Format(strSql + "{0} "+orderBy+" offset {1} rows  fetch next {2} rows only ",where,(pageIndex-1)*pageSize,pageSize);
            using (var conn = ConnentionFactory.GetOpenSqlConnection())
            {
                var list = conn.Query<T_BLOG_CONTENT>(strFormat).ToList();
                return list;
            }
        }

        public int GetCount(string where)
        {
            string strSql = " SELECT COUNT(1) FROM T_BLOG_CONTENT b ";
            strSql += " INNER join T_BLOG_CATELOG_REL g on g.BlogID=b.BlogID ";
            if (!string.IsNullOrEmpty(where))
            {
                strSql += $" WHERE {where}";
            }
            using (var connection = ConnentionFactory.GetOpenSqlConnection())
            {
                int res = connection.ExecuteScalar<int>(strSql);
                return res;
            }
        }

        public T_BLOG_CONTENT GetModel(string where)
        {
            var src = GetList(where);
            return src?.First();
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
