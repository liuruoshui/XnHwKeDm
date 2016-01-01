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
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelper.GetMaxID("MemberId", "Members"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string UserName,int MemberId)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Members");
			strSql.Append(" where UserName=@UserName and MemberId=@MemberId ");
			SqlParameter[] parameters = {
					new SqlParameter("@UserName", SqlDbType.NVarChar,50),
					new SqlParameter("@MemberId", SqlDbType.Int,4)			};
			parameters[0].Value = UserName;
			parameters[1].Value = MemberId;

			return DbHelper.Exists(strSql.ToString(),parameters);
		}


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
		/// 删除一条数据
		/// </summary>
		public bool Delete(int MemberId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Members ");
			strSql.Append(" where MemberId=@MemberId");
			SqlParameter[] parameters = {
					new SqlParameter("@MemberId", SqlDbType.Int,4)
			};
			parameters[0].Value = MemberId;

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
		public bool Delete(string UserName,int MemberId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Members ");
			strSql.Append(" where UserName=@UserName and MemberId=@MemberId ");
			SqlParameter[] parameters = {
					new SqlParameter("@UserName", SqlDbType.NVarChar,50),
					new SqlParameter("@MemberId", SqlDbType.Int,4)			};
			parameters[0].Value = UserName;
			parameters[1].Value = MemberId;

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
		public bool DeleteList(string MemberIdlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Members ");
			strSql.Append(" where MemberId in ("+MemberIdlist + ")  ");
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
		public SXEdu2XHKD.Domain.Entities.Member GetModel(int MemberId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 MemberId,SxEduUserInfo,SXEduUserName,School,Grade,ClassName,UserName,PassWord,BirthDay,Email,Name,RegisterTime,QQ,UserType,ParentName,UserStatus from Members ");
			strSql.Append(" where MemberId=@MemberId");
			SqlParameter[] parameters = {
					new SqlParameter("@MemberId", SqlDbType.Int,4)
			};
			parameters[0].Value = MemberId;

			SXEdu2XHKD.Domain.Entities.Member model=new SXEdu2XHKD.Domain.Entities.Member();
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
			strSql.Append(" MemberId,SxEduUserInfo,SXEduUserName,School,Grade,ClassName,UserName,PassWord,BirthDay,Email,Name,RegisterTime,QQ,UserType,ParentName,UserStatus ");
			strSql.Append(" FROM Members ");
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
			strSql.Append("select count(1) FROM Members ");
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
				strSql.Append("order by T.MemberId desc");
			}
			strSql.Append(")AS Row, T.*  from Members T ");
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
			parameters[0].Value = "Members";
			parameters[1].Value = "MemberId";
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

