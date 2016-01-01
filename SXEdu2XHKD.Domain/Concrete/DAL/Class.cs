using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using SXEdu2XHKD.Domain.Common;


namespace SXEdu2XHKD.Domain.Concrete.DAL
{
	/// <summary>
	/// 数据访问类:Classes
	/// </summary>
	public partial class Class
	{
		public Class()
		{}
		#region  BasicMethod


		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string ClassName,int SchoolId,int GradeId)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Classes");
			strSql.Append(" where ClassName=@ClassName and SchoolId=@SchoolId and GradeId=@GradeId ");
			SqlParameter[] parameters = {
					new SqlParameter("@ClassName", SqlDbType.NVarChar,50),
					new SqlParameter("@SchoolId", SqlDbType.Int,4),
					new SqlParameter("@GradeId", SqlDbType.Int,4)			};
			parameters[0].Value = ClassName;
			parameters[1].Value = SchoolId;
			parameters[2].Value = GradeId;

			return DbHelper.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(SXEdu2XHKD.Domain.Entities.Class model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Classes(");
			strSql.Append("ClassName,SchoolId,GradeId)");
			strSql.Append(" values (");
			strSql.Append("@ClassName,@SchoolId,@GradeId)");
			SqlParameter[] parameters = {
					new SqlParameter("@ClassName", SqlDbType.NVarChar,50),
					new SqlParameter("@SchoolId", SqlDbType.Int,4),
					new SqlParameter("@GradeId", SqlDbType.Int,4)};
			parameters[0].Value = model.ClassName;
			parameters[1].Value = model.SchoolId;
			parameters[2].Value = model.GradeId;

			int rows=DbHelper.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		#endregion  BasicMethod
	}
}

