using SXEdu2XHKD.Domain.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Dapper;

namespace SXEdu2XHKD.Domain.Concrete.DAL
{
    public class LoginRecordDal
    {

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(SXEdu2XHKD.Domain.Entities.LoginRecord loginRecord)
        {
            bool isSuccessful = true;
            using (IDbConnection conn = DapperHelper.ConnectToSxEdu())
            {
                try
                {
                    StringBuilder queryStr = new StringBuilder();
                    queryStr.Append("insert into LoginRecords(");
                    queryStr.Append("LogInTime,LogOutTime,MemberId,SXEduUserName)");
                    queryStr.Append(" values (");
                    queryStr.Append("@LogInTime,@LogOutTime,@MemberId,@SXEduUserName)");
                    queryStr.Append(";select @@IDENTITY");
                    conn.Query(queryStr.ToString(), loginRecord);
                }
                catch (Exception ex)
                {
                    isSuccessful = false;
                }
            }
            return isSuccessful;
        }

        /// <summary>
        /// 根据日期获取登陆记录
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public IEnumerable<SXEdu2XHKD.Domain.Entities.LoginRecord> GetLoginRecordByDate(DateTime date)
        {

            using (IDbConnection conn = DapperHelper.ConnectToSxEdu())
            {
                StringBuilder queryStr = new StringBuilder();
                queryStr.Append("select * from LoginRecords ");

                queryStr.Append(" where LogInTime between @DateStart and @DateEnd");
                DateTime dateStart = date;
                DateTime dateEnd = date.AddDays(1);

                return conn.Query<SXEdu2XHKD.Domain.Entities.LoginRecord>(queryStr.ToString(), new { DateStart = dateStart, DateEnd = dateEnd });
            }
        }
    }
}
