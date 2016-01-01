using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;
using SXEdu2XHKD.Domain.Common;//Please add references
namespace SXEdu2XHKD.Domain.Concrete.DAL
{
	/// <summary>
	/// 数据访问类:LoginRecords
	/// </summary>
	public partial class LoginRecord
	{
		public LoginRecord()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelper.GetMaxID("LoginRecordId", "LoginRecords"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int LoginRecordId)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from LoginRecords");
			strSql.Append(" where LoginRecordId=@LoginRecordId");
			SqlParameter[] parameters = {
					new SqlParameter("@LoginRecordId", SqlDbType.Int,4)
			};
			parameters[0].Value = LoginRecordId;

			return DbHelper.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(SXEdu2XHKD.Domain.Entities.LoginRecord model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into LoginRecords(");
			strSql.Append("LogInTime,LogOutTime,MemberId,SXEduUserName)");
			strSql.Append(" values (");
			strSql.Append("@LogInTime,@LogOutTime,@MemberId,@SXEduUserName)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@LogInTime", SqlDbType.DateTime),
					new SqlParameter("@LogOutTime", SqlDbType.DateTime),
					new SqlParameter("@MemberId", SqlDbType.Int,4),
					new SqlParameter("@SXEduUserName", SqlDbType.NVarChar,50)};
			parameters[0].Value = model.LogInTime;
			parameters[1].Value = model.LogOutTime;
			parameters[2].Value = model.MemberId;
			parameters[3].Value = model.SXEduUserName;

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
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(SXEdu2XHKD.Domain.Entities.LoginRecord model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update LoginRecords set ");
			strSql.Append("LogInTime=@LogInTime,");
			strSql.Append("LogOutTime=@LogOutTime,");
			strSql.Append("MemberId=@MemberId,");
			strSql.Append("SXEduUserName=@SXEduUserName");
			strSql.Append(" where LoginRecordId=@LoginRecordId");
			SqlParameter[] parameters = {
					new SqlParameter("@LogInTime", SqlDbType.DateTime),
					new SqlParameter("@LogOutTime", SqlDbType.DateTime),
					new SqlParameter("@MemberId", SqlDbType.Int,4),
					new SqlParameter("@SXEduUserName", SqlDbType.NVarChar,50),
					new SqlParameter("@LoginRecordId", SqlDbType.Int,4)};
			parameters[0].Value = model.LogInTime;
			parameters[1].Value = model.LogOutTime;
			parameters[2].Value = model.MemberId;
			parameters[3].Value = model.SXEduUserName;
			parameters[4].Value = model.LoginRecordId;

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

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int LoginRecordId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from LoginRecords ");
			strSql.Append(" where LoginRecordId=@LoginRecordId");
			SqlParameter[] parameters = {
					new SqlParameter("@LoginRecordId", SqlDbType.Int,4)
			};
			parameters[0].Value = LoginRecordId;

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
		/// <summary>
		/// 批量删除数据
		/// </summary>
		public bool DeleteList(string LoginRecordIdlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from LoginRecords ");
			strSql.Append(" where LoginRecordId in ("+LoginRecordIdlist + ")  ");
			int rows=DbHelper.ExecuteSql(strSql.ToString());
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public SXEdu2XHKD.Domain.Entities.LoginRecord GetModel(int LoginRecordId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 LoginRecordId,LogInTime,LogOutTime,MemberId,SXEduUserName from LoginRecords ");
			strSql.Append(" where LoginRecordId=@LoginRecordId");
			SqlParameter[] parameters = {
					new SqlParameter("@LoginRecordId", SqlDbType.Int,4)
			};
			parameters[0].Value = LoginRecordId;

			SXEdu2XHKD.Domain.Entities.LoginRecord model=new SXEdu2XHKD.Domain.Entities.LoginRecord();
			DataSet ds=DbHelper.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				return DataRowToModel(ds.Tables[0].Rows[0]);
			}
			else
			{
				return null;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public SXEdu2XHKD.Domain.Entities.LoginRecord DataRowToModel(DataRow row)
		{
			SXEdu2XHKD.Domain.Entities.LoginRecord model=new SXEdu2XHKD.Domain.Entities.LoginRecord();
			if (row != null)
			{
				if(row["LoginRecordId"]!=null && row["LoginRecordId"].ToString()!="")
				{
					model.LoginRecordId=int.Parse(row["LoginRecordId"].ToString());
				}
				if(row["LogInTime"]!=null && row["LogInTime"].ToString()!="")
				{
					model.LogInTime=DateTime.Parse(row["LogInTime"].ToString());
				}
				if(row["LogOutTime"]!=null && row["LogOutTime"].ToString()!="")
				{
					model.LogOutTime=DateTime.Parse(row["LogOutTime"].ToString());
				}
				if(row["MemberId"]!=null && row["MemberId"].ToString()!="")
				{
					model.MemberId=int.Parse(row["MemberId"].ToString());
				}
				if(row["SXEduUserName"]!=null)
				{
					model.SXEduUserName=row["SXEduUserName"].ToString();
				}
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select LoginRecordId,LogInTime,LogOutTime,MemberId,SXEduUserName ");
			strSql.Append(" FROM LoginRecords ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelper.Query(strSql.ToString());
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(" LoginRecordId,LogInTime,LogOutTime,MemberId,SXEduUserName ");
			strSql.Append(" FROM LoginRecords ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelper.Query(strSql.ToString());
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM LoginRecords ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			object obj = DbHelper.GetSingle(strSql.ToString());
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("SELECT * FROM ( ");
			strSql.Append(" SELECT ROW_NUMBER() OVER (");
			if (!string.IsNullOrEmpty(orderby.Trim()))
			{
				strSql.Append("order by T." + orderby );
			}
			else
			{
				strSql.Append("order by T.LoginRecordId desc");
			}
			strSql.Append(")AS Row, T.*  from LoginRecords T ");
			if (!string.IsNullOrEmpty(strWhere.Trim()))
			{
				strSql.Append(" WHERE " + strWhere);
			}
			strSql.Append(" ) TT");
			strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
			return DbHelper.Query(strSql.ToString());
		}

		/*
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		{
			SqlParameter[] parameters = {
					new SqlParameter("@tblName", SqlDbType.VarChar, 255),
					new SqlParameter("@fldName", SqlDbType.VarChar, 255),
					new SqlParameter("@PageSize", SqlDbType.Int),
					new SqlParameter("@PageIndex", SqlDbType.Int),
					new SqlParameter("@IsReCount", SqlDbType.Bit),
					new SqlParameter("@OrderType", SqlDbType.Bit),
					new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
					};
			parameters[0].Value = "LoginRecords";
			parameters[1].Value = "LoginRecordId";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelper.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

