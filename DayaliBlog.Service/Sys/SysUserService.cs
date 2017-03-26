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
            strSql.Append(" where UserName=@UserName and Password=@PassWrod");
            using (var conn=ConnentionFactory.GetOpenSqlConnection())
            {
                var list= conn.Query<T_SYS_USER>(strSql.ToString(), new {UserName = userName, PassWord = passWord}).ToList();
                return list;
            }
        }
    }
}
