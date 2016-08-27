using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace login.Models
{
    /// <summary>
    /// 通用数据访问类
    /// </summary>
    public class SQLHelper
    {
        //定义链接字符串
        private static string connString = ConfigurationManager.ConnectionStrings["connString"].ToString();

        public static MySqlDataReader GetReader(string sql)
        {
            MySqlConnection conn = new MySqlConnection(connString);
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            try
            {
                conn.Open();
                return cmd.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch (Exception exception)
            {
                //将错误信息写入日志
                throw exception;
            }
        }
    }
}