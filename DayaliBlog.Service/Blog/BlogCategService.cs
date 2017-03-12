using System;
using System.Collections.Generic;
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
        public int InsertCateg(T_BLOG_CATELOG categry)
        {
            using (var conn = ConnentionFactory.GetOpenSqlConnection())
            {
                var resId = conn.Query<int>(@"INSERT INTO [dbo].[T_BLOG_CATELOG](CatelogName,CreateUser,UpdateUser) VALUES (@CatelogName,@CreateUser,@UpdateUser);" +
                    " SELECT  @@IDENTITY",categry).First();
                return resId;
            }
        }
    }
}
