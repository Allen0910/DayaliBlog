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
        /// <summary>
        /// 插入博客类别
        /// </summary>
        /// <returns>插入的博客类别ID</returns>
        public int Insert(T_BLOG_CATELOG categry)
        {
            using (var conn = ConnentionFactory.GetOpenSqlConnection())
            {
                var resId = conn.Query<int>(@"INSERT INTO [dbo].[T_BLOG_CATELOG](CatelogName,CreateUser,UpdateUser) VALUES (@CatelogName,@CreateUser,@UpdateUser);" +
                    " SELECT  @@IDENTITY",categry).First();
                return resId;
            }
        }

        public int Insert(T_BLOG_CATELOG categry,IDbTransaction transaction)
        {
            using (var conn = ConnentionFactory.GetOpenSqlConnection())
            {
                var resId = conn.Query<int>(@"INSERT INTO [dbo].[T_BLOG_CATELOG](CatelogName,CreateUser,UpdateUser) VALUES (@CatelogName,@CreateUser,@UpdateUser);" +
                    " SELECT  @@IDENTITY", categry, transaction).First();
                return resId;
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
            strSql.Append("CatelogID=@CatelogID,");
            strSql.Append("ParentCategID=@ParentCategID,");
            strSql.Append("CatelogName=@CatelogName,");
            strSql.Append("CreateUser=@CreateUser,");
            strSql.Append("CreateTime=@CreateTime,");
            strSql.Append("UpdateUser=@UpdateUser,");
            strSql.Append("UpdateTime=@UpdateTime,");
            strSql.Append("Remark=@Remark");
            strSql.Append("WHERE CatelogID=@CatelogID");
            using (var conn=ConnentionFactory.GetOpenSqlConnection())
            {
                int resId=conn.Execute(strSql.ToString(), categry);
                return resId > 0;
            }
        }

        /// <summary>
        /// 获取博客类别实体
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public List<T_BLOG_CATELOG> GetList(string where)
        {
            using (var conn=ConnentionFactory.GetOpenSqlConnection())
            {
                string strSql =
                    "select CatelogID,ParentCategID,CatelogName,CreateUser,CreateTime,UpdateUser,UpdateTime,Remark from T_BLOG_CATELOG ";
                if (!string.IsNullOrEmpty(where))
                {
                    strSql += "where " + where;
                }
                var list= conn.Query<T_BLOG_CATELOG>(strSql).ToList();
                return list;
            }
        }

        /// <summary>
        /// 删除博客类别
        /// </summary>
        /// <param name="categId"></param>
        /// <returns></returns>
        public bool Delete(int categId)
        {
            using (var conn = ConnentionFactory.GetOpenSqlConnection())
            {
                int resId = conn.Execute("delete from dbo.T_BLOG_CATELOG where CatelogID=@id", new{id = categId});
                if (resId > 0)
                    return true;
                return false;
            }
        }
    }
}
