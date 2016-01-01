using MySql.Data.MySqlClient;
using SXEdu2XHKD.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dapper;

namespace SXEdu2XHKD.Domain.Concrete.DAL
{
    public class MemberDal
    {
        /// <summary>
        /// 获取全部用户列表
        /// </summary>
        /// <returns></returns>
        public IEnumerable<SXEdu2XHKD.Domain.Entities.Member> GetAllMemberList()
        {
            using (MySqlConnection conn = DapperHelper.ConnectToSxEdu())
            {
                const string query = "SELECT * FROM `members`;";
                return conn.Query<SXEdu2XHKD.Domain.Entities.Member>(query, null);
            }
        }
    }
}
