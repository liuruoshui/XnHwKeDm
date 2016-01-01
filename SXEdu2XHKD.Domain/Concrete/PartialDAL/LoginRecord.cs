using SXEdu2XHKD.Domain.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace SXEdu2XHKD.Domain.Concrete.DAL
{
    public partial class LoginRecord
    {
        public List<SXEdu2XHKD.Domain.Entities.LoginRecord> GetLoginRecordByDate(DateTime date)
        {
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select LoginRecordId,LogInTime,LogOutTime,MemberId,SXEduUserName from LoginRecords ");
            DateTime dateStart = date;
            DateTime dateEnd = date.AddDays(1);

            strSql.Append(" where LogInTime between @DateStart and @DateEnd");
			SqlParameter[] parameters = {
					new SqlParameter("@DateStart", SqlDbType.DateTime),
                    new SqlParameter("@DateEnd", SqlDbType.DateTime)
			};
			parameters[0].Value = dateStart;
            parameters[1].Value = dateEnd;


			DataSet ds=DbHelper.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
                List<SXEdu2XHKD.Domain.Entities.LoginRecord> loginRecordList = new List<Entities.LoginRecord>();
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    loginRecordList.Add(DataRowToModel(row));
                }
                return loginRecordList;
			}
			else
			{
				return null;
			}
        }
    }
}
