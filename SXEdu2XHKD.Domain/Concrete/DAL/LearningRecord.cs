using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;
using SXEdu2XHKD.Domain.Common;//Please add references
namespace SXEdu2XHKD.Domain.Concrete.DAL
{
	/// <summary>
	/// 数据访问类:LearningRecords
	/// </summary>
	public partial class LearningRecord
	{
		public LearningRecord()
		{}
		#region  BasicMethod
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(SXEdu2XHKD.Domain.Entities.LearningRecord model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into LearningRecords(");
			strSql.Append("MemberId,CourseCode,RecordTime,SXEduUserName)");
			strSql.Append(" values (");
			strSql.Append("@MemberId,@CourseCode,@RecordTime,@SXEduUserName)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@MemberId", SqlDbType.Int,4),
					new SqlParameter("@CourseCode", SqlDbType.NVarChar,20),
					new SqlParameter("@RecordTime", SqlDbType.DateTime),
					new SqlParameter("@SXEduUserName", SqlDbType.NVarChar,50)};
			parameters[0].Value = model.MemberId;
			parameters[1].Value = model.CourseCode;
			parameters[2].Value = model.RecordTime;
			parameters[3].Value = model.SxEduUserName;

			object obj = DbHelper.GetSingle(strSql.ToString(),parameters);
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}
		#endregion  BasicMethod
    }
}

