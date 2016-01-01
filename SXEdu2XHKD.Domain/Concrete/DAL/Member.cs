using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;
using SXEdu2XHKD.Domain.Common;//Please add references
namespace SXEdu2XHKD.Domain.Concrete.DAL
{
	/// <summary>
	/// 数据访问类:Members
	/// </summary>
	public partial class Member
	{
		#region  BasicMethod

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(SXEdu2XHKD.Domain.Entities.Member model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Members(");
			strSql.Append("SxEduUserInfo,SXEduUserName,School,Grade,ClassName,UserName,PassWord,BirthDay,Email,Name,RegisterTime,QQ,UserType,ParentName,UserStatus)");
			strSql.Append(" values (");
			strSql.Append("@SxEduUserInfo,@SXEduUserName,@School,@Grade,@ClassName,@UserName,@PassWord,@BirthDay,@Email,@Name,@RegisterTime,@QQ,@UserType,@ParentName,@UserStatus)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@SxEduUserInfo", SqlDbType.NVarChar,-1),
					new SqlParameter("@SXEduUserName", SqlDbType.NVarChar,50),
					new SqlParameter("@School", SqlDbType.Int,4),
					new SqlParameter("@Grade", SqlDbType.Int,4),
					new SqlParameter("@ClassName", SqlDbType.NVarChar,50),
					new SqlParameter("@UserName", SqlDbType.NVarChar,50),
					new SqlParameter("@PassWord", SqlDbType.NVarChar,50),
					new SqlParameter("@BirthDay", SqlDbType.DateTime),
					new SqlParameter("@Email", SqlDbType.NVarChar,50),
					new SqlParameter("@Name", SqlDbType.NVarChar,50),
					new SqlParameter("@RegisterTime", SqlDbType.DateTime),
					new SqlParameter("@QQ", SqlDbType.NVarChar,50),
					new SqlParameter("@UserType", SqlDbType.Int,4),
					new SqlParameter("@ParentName", SqlDbType.NVarChar,50),
					new SqlParameter("@UserStatus", SqlDbType.Int,4)};
			parameters[0].Value = model.SxEduUserInfo;
			parameters[1].Value = model.SXEduUserName;
			parameters[2].Value = model.School;
			parameters[3].Value = model.Grade;
			parameters[4].Value = model.ClassName;
			parameters[5].Value = model.UserName;
			parameters[6].Value = model.PassWord;
			parameters[7].Value = model.BirthDay;
			parameters[8].Value = model.Email;
			parameters[9].Value = model.Name;
			parameters[10].Value = model.RegisterTime;
			parameters[11].Value = model.QQ;
			parameters[12].Value = model.UserType;
			parameters[13].Value = model.ParentName;
			parameters[14].Value = model.UserStatus;

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
		public bool Update(SXEdu2XHKD.Domain.Entities.Member model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Members set ");
			strSql.Append("SxEduUserInfo=@SxEduUserInfo,");
			strSql.Append("SXEduUserName=@SXEduUserName,");
			strSql.Append("School=@School,");
			strSql.Append("Grade=@Grade,");
			strSql.Append("ClassName=@ClassName,");
			strSql.Append("PassWord=@PassWord,");
			strSql.Append("BirthDay=@BirthDay,");
			strSql.Append("Email=@Email,");
			strSql.Append("Name=@Name,");
			strSql.Append("RegisterTime=@RegisterTime,");
			strSql.Append("QQ=@QQ,");
			strSql.Append("UserType=@UserType,");
			strSql.Append("ParentName=@ParentName,");
			strSql.Append("UserStatus=@UserStatus");
			strSql.Append(" where MemberId=@MemberId");
			SqlParameter[] parameters = {
					new SqlParameter("@SxEduUserInfo", SqlDbType.NVarChar,-1),
					new SqlParameter("@SXEduUserName", SqlDbType.NVarChar,50),
					new SqlParameter("@School", SqlDbType.Int,4),
					new SqlParameter("@Grade", SqlDbType.Int,4),
					new SqlParameter("@ClassName", SqlDbType.NVarChar,50),
					new SqlParameter("@PassWord", SqlDbType.NVarChar,50),
					new SqlParameter("@BirthDay", SqlDbType.DateTime),
					new SqlParameter("@Email", SqlDbType.NVarChar,50),
					new SqlParameter("@Name", SqlDbType.NVarChar,50),
					new SqlParameter("@RegisterTime", SqlDbType.DateTime),
					new SqlParameter("@QQ", SqlDbType.NVarChar,50),
					new SqlParameter("@UserType", SqlDbType.Int,4),
					new SqlParameter("@ParentName", SqlDbType.NVarChar,50),
					new SqlParameter("@UserStatus", SqlDbType.Int,4),
					new SqlParameter("@MemberId", SqlDbType.Int,4),
					new SqlParameter("@UserName", SqlDbType.NVarChar,50)};
			parameters[0].Value = model.SxEduUserInfo;
			parameters[1].Value = model.SXEduUserName;
			parameters[2].Value = model.School;
			parameters[3].Value = model.Grade;
			parameters[4].Value = model.ClassName;
			parameters[5].Value = model.PassWord;
			parameters[6].Value = model.BirthDay;
			parameters[7].Value = model.Email;
			parameters[8].Value = model.Name;
			parameters[9].Value = model.RegisterTime;
			parameters[10].Value = model.QQ;
			parameters[11].Value = model.UserType;
			parameters[12].Value = model.ParentName;
			parameters[13].Value = model.UserStatus;
			parameters[14].Value = model.MemberId;
			parameters[15].Value = model.UserName;

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
		/// 得到一个对象实体
		/// </summary>
		public SXEdu2XHKD.Domain.Entities.Member DataRowToModel(DataRow row)
		{
			SXEdu2XHKD.Domain.Entities.Member model=new SXEdu2XHKD.Domain.Entities.Member();
			if (row != null)
			{
				if(row["MemberId"]!=null && row["MemberId"].ToString()!="")
				{
					model.MemberId=int.Parse(row["MemberId"].ToString());
				}
				if(row["SxEduUserInfo"]!=null)
				{
					model.SxEduUserInfo=row["SxEduUserInfo"].ToString();
				}
				if(row["SXEduUserName"]!=null)
				{
					model.SXEduUserName=row["SXEduUserName"].ToString();
				}
				if(row["School"]!=null && row["School"].ToString()!="")
				{
					model.School=int.Parse(row["School"].ToString());
				}
				if(row["Grade"]!=null && row["Grade"].ToString()!="")
				{
					model.Grade=int.Parse(row["Grade"].ToString());
				}
				if(row["ClassName"]!=null)
				{
					model.ClassName=row["ClassName"].ToString();
				}
				if(row["UserName"]!=null)
				{
					model.UserName=row["UserName"].ToString();
				}
				if(row["PassWord"]!=null)
				{
					model.PassWord=row["PassWord"].ToString();
				}
				if(row["BirthDay"]!=null && row["BirthDay"].ToString()!="")
				{
					model.BirthDay=DateTime.Parse(row["BirthDay"].ToString());
				}
				if(row["Email"]!=null)
				{
					model.Email=row["Email"].ToString();
				}
				if(row["Name"]!=null)
				{
					model.Name=row["Name"].ToString();
				}
				if(row["RegisterTime"]!=null && row["RegisterTime"].ToString()!="")
				{
					model.RegisterTime=DateTime.Parse(row["RegisterTime"].ToString());
				}
				if(row["QQ"]!=null)
				{
					model.QQ=row["QQ"].ToString();
				}
				if(row["UserType"]!=null && row["UserType"].ToString()!="")
				{
					model.UserType=int.Parse(row["UserType"].ToString());
				}
				if(row["ParentName"]!=null)
				{
					model.ParentName=row["ParentName"].ToString();
				}
				if(row["UserStatus"]!=null && row["UserStatus"].ToString()!="")
				{
					model.UserStatus=int.Parse(row["UserStatus"].ToString());
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
			strSql.Append("select MemberId,SxEduUserInfo,SXEduUserName,School,Grade,ClassName,UserName,PassWord,BirthDay,Email,Name,RegisterTime,QQ,UserType,ParentName,UserStatus ");
			strSql.Append(" FROM Members ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelper.Query(strSql.ToString());
		}
		#endregion  BasicMethod
	}
}

