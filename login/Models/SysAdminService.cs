using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace login.Models
{
    /// <summary>
    /// 管理员数据访问类
    /// </summary>
    public class SysAdminService
    {
        /// <summary>
        /// 根据登录账号和密码登录
        /// </summary>
        /// <param name="objAdmin"></param>
        /// <returns></returns>
        public SysAdmin AdminLogin(SysAdmin objAdmin)
        {
            string sql = "select AdminName from user_admin where LoginId={0} and LoginPwd='{1}'";
            sql = string.Format(sql, objAdmin.LoginId, objAdmin.LoginPwd);
            MySqlDataReader objReader = SQLHelper.GetReader(sql);
            if (objReader.Read())
            {
                objAdmin.AdminName = objReader["AdminName"].ToString();
            }
            else
            {
                objAdmin = null;
            }
            objReader.Close();
            return objAdmin;
        }
        public SysAdmin AdminRegister(SysAdmin user)
        {
            string sql = "insert into user_admin(LoginPwd,LoginId,AdminName) values('{0}',{1},'{2}')";
            sql = string.Format(sql, user.LoginPwd, user.LoginId, user.AdminName);
            MySqlDataReader objReader = SQLHelper.GetReader(sql);
            if (!objReader.Read())
            {
                user = null;
            }
            objReader.Close();
            return user;
        }
    }
}