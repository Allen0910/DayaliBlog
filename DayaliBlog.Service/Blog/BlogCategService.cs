using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Dapper;
using DayaliBlog.Service.Sys;
using System.Linq;
using DayaliBlog.Model.Blog;


namespace DayaliBlog.Service.Blog
{
    public class BlogCategService
    {
        public string ConnStr;

        public BlogCategService(string conn)
        {
            ConnStr = conn;
        }
        /// <summary>
        /// 插入博客类别
        /// </summary>
        /// <returns>插入的博客类别ID</returns>
        public int Insert(T_BLOG_CATELOG categry)
        {
            using (var conn = ConnentionFactory.GetOpenSqlConnection(ConnStr))
            {
                var resBlogID = conn.Query<int>(@"INSERT INTO [T_BLOG_CATELOG](CatelogName,Remark,CreateUser) VALUES (@CatelogName,@Remark,@CreateUser);" +
                    " SELECT  @@IDENTITY",categry).First();
                return resBlogID;
            }
        }

        public int Insert(T_BLOG_CATELOG categry,IDbTransaction transaction)
        {
            using (var conn = ConnentionFactory.GetOpenSqlConnection(ConnStr))
            {
                var resBlogID = conn.Query<int>(@"INSERT INTO [dbo].[T_BLOG_CATELOG](CatelogName,Remark,CreateUser,UpdateUser) VALUES (@CatelogName,@Remark,@CreateUser,@UpdateUser);" +
                    " SELECT  @@IDENTITY", categry, transaction).First();
                return resBlogID;
            }
        }

        /// <summary>
        /// 修改博客类别
        /// </summary>
        /// <param name="categry"></param>
        /// <returns></returns>
        public bool Update(T_BLOG_CATELOG categry)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update T_BLOG_CATELOG set ");
            strSql.Append("ParentCategID=@ParentCategID,");
            strSql.Append("CatelogName=@CatelogName,");
            strSql.Append("UpdateUser=@UpdateUser,");
            strSql.Append("UpdateTime=@UpdateTime,");
            strSql.Append("Remark=@Remark");
            strSql.Append(" WHERE CatelogID=@CatelogID");
            using (var conn=ConnentionFactory.GetOpenSqlConnection(ConnStr))
            {
                int resBlogID=conn.Execute(strSql.ToString(), categry);
                return resBlogID > 0;
            }
        }

        /// <summary>
        /// 获取博客类别实体
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public List<T_BLOG_CATELOG> GetList(string where)
        {
            using (var conn=ConnentionFactory.GetOpenSqlConnection(ConnStr))
            {
                string strSql =
                    "select CatelogID,ParentCategID,CatelogName,CreateUser,CreateTime,UpdateUser,UpdateTime,Remark from T_BLOG_CATELOG ";
                if (!string.IsNullOrEmpty(where))
                {
                    strSql += "where " + where;
                }
                strSql += " order by CreateTime DESC";
                var list= conn.Query<T_BLOG_CATELOG>(strSql).ToList();
                return list;
            }
        }

        /// <summary>
        /// 删除博客类别
        /// </summary>
        /// <param name="categBlogID"></param>
        /// <returns></returns>
        public bool Delete(int categBlogID)
        {
            using (var conn = ConnentionFactory.GetOpenSqlConnection(ConnStr))
            {
                int resBlogID = conn.Execute("delete from T_BLOG_CATELOG where CatelogID=@id", new{id = categBlogID});
                if (resBlogID > 0)
                    return true;
                return false;
            }
        }
    }
}
