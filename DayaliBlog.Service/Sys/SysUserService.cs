using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dapper;
using DayaliBlog.Model.Sys;

namespace DayaliBlog.Service.Sys
{
    public class SysUserService
    {
        /// <summary>
        /// 根据用户名和密码获取用户信息
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="passWord"></param>
        /// <returns></returns>
        public List<T_SYS_USER> GetList(string userName, string passWord)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select UserID,UserName,Password,PersonalID,QQOpenid,CreateUser,CreateTime,UpdateUser,UpdateTime ");
            strSql.Append(" FROM T_SYS_USER ");
            strSql.Append(" where UserName=@userName and Password=@passWord");
            using (var conn=ConnentionFactory.GetOpenSqlConnection())
            {
                var list= conn.Query<T_SYS_USER>(strSql.ToString(), new {UserName = userName, PassWord = passWord}).ToList();
                return list;
            }
        }

        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Update(T_SYS_USER model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update T_SYS_USER set ");
            strSql.Append("Password=@Password");
            strSql.Append(" where UserID=@UserID");
            using (var conn = ConnentionFactory.GetOpenSqlConnection())
            {
                int resUserId = conn.Execute(strSql.ToString(), model);
                return resUserId > 0;
            }
        }

    }
}
