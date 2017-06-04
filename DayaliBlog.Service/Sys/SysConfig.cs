using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dapper;
using DayaliBlog.Model.Sys;

namespace DayaliBlog.Service.Sys
{
    public static class SysConfig
    {
        public static string ConnStr { get; set; }
        /// <summary>
        /// 性别
        /// </summary>
        public const int Gender = 1;

        /// <summary>
        /// 博客类型
        /// </summary>
        public const int BlogType = 2;

        /// <summary>
        /// 博客状态
        /// </summary>
        public const int BlogState = 3;

        /// <summary>
        /// 收藏状态
        /// </summary>
        public const int CollectState = 4;

        /// <summary>
        /// 回复状态
        /// </summary>
        public const int ReplyState = 5;

        /// <summary>
        /// 用户类型
        /// </summary>
        public const int UserType = 6;

        public static List<T_SYS_CONFIG> GetConfigList(int configType)
        {
            string strSql = "SELECT * FROM T_SYS_CONFIG WHERE ID="+configType;
            using (var conn=ConnentionFactory.GetOpenSqlConnection(ConnStr))
            {
                var list = conn.Query<T_SYS_CONFIG>(strSql).ToList();
                return list;
            }
        }

        public static T_SYS_CONFIG GetConfig(int configType, int subBlogID)
        {
            string strSql = "SELECT * FROM T_SYS_CONFIG WHERE ID="+configType+" and SUB_ID="+subBlogID;
            using (var conn=ConnentionFactory.GetOpenSqlConnection(ConnStr))
            {
                var config = conn.QueryFirst<T_SYS_CONFIG>(strSql);
                return config;
            }

        }
    }
}
