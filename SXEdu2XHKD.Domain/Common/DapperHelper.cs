using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Dapper;
using System.Data;

namespace SXEdu2XHKD.Domain.Common
{
    public class DapperHelper
    {
        /// <summary>
        /// 打开SxEdu数据库
        /// </summary>
        /// <returns></returns>
        public static IDbConnection ConnectToSxEdu()
        {
            return OpenSqlConnection(ConfigurationManager.AppSettings["ConnectionStringSXEdu"]);
        }

        /// <summary>
        /// 打开Pp22数据库
        /// </summary>
        /// <returns></returns>
        public static IDbConnection ConnectToPp22()
        {
            return OpenSqlConnection(ConfigurationManager.AppSettings["ConnectionStringpp22"]);
        }

        /// <summary>
        /// 连接至mysql数据库
        /// </summary>
        /// <param name="connectionString">连接字符串</param>
        /// <returns></returns>
        public static MySqlConnection OpenMySqlConnection(string connectionString)
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();
            return connection;
        }

        /// <summary>
        /// 连接至sqlserver数据库
        /// </summary>
        /// <param name="connectionString">连接字符串</param>
        /// <returns></returns>
        public static SqlConnection OpenSqlConnection(string connectionString)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            return connection;
        }
    }
}