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
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelper.GetMaxID("SchoolId", "Classes"); 
		}

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
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(SXEdu2XHKD.Domain.Entities.Class model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Classes set ");
//#warning 系统发现缺少更新的字段，请手工确认如此更新是否正确！ 
			strSql.Append("ClassName=@ClassName,");
			strSql.Append("SchoolId=@SchoolId,");
			strSql.Append("GradeId=@GradeId");
			strSql.Append(" where ClassName=@ClassName and SchoolId=@SchoolId and GradeId=@GradeId ");
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

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(string ClassName,int SchoolId,int GradeId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Classes ");
			strSql.Append(" where ClassName=@ClassName and SchoolId=@SchoolId and GradeId=@GradeId ");
			SqlParameter[] parameters = {
					new SqlParameter("@ClassName", SqlDbType.NVarChar,50),
					new SqlParameter("@SchoolId", SqlDbType.Int,4),
					new SqlParameter("@GradeId", SqlDbType.Int,4)			};
			parameters[0].Value = ClassName;
			parameters[1].Value = SchoolId;
			parameters[2].Value = GradeId;

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
		public SXEdu2XHKD.Domain.Entities.Class GetModel(string ClassName,int SchoolId,int GradeId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ClassName,SchoolId,GradeId from Classes ");
			strSql.Append(" where ClassName=@ClassName and SchoolId=@SchoolId and GradeId=@GradeId ");
			SqlParameter[] parameters = {
					new SqlParameter("@ClassName", SqlDbType.NVarChar,50),
					new SqlParameter("@SchoolId", SqlDbType.Int,4),
					new SqlParameter("@GradeId", SqlDbType.Int,4)			};
			parameters[0].Value = ClassName;
			parameters[1].Value = SchoolId;
			parameters[2].Value = GradeId;

			SXEdu2XHKD.Domain.Entities.Class model=new SXEdu2XHKD.Domain.Entities.Class();
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
		public SXEdu2XHKD.Domain.Entities.Class DataRowToModel(DataRow row)
		{
			SXEdu2XHKD.Domain.Entities.Class model=new SXEdu2XHKD.Domain.Entities.Class();
			if (row != null)
			{
				if(row["ClassName"]!=null)
				{
					model.ClassName=row["ClassName"].ToString();
				}
				if(row["SchoolId"]!=null && row["SchoolId"].ToString()!="")
				{
					model.SchoolId=int.Parse(row["SchoolId"].ToString());
				}
				if(row["GradeId"]!=null && row["GradeId"].ToString()!="")
				{
					model.GradeId=int.Parse(row["GradeId"].ToString());
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
			strSql.Append("select ClassName,SchoolId,GradeId ");
			strSql.Append(" FROM Classes ");
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
			strSql.Append(" ClassName,SchoolId,GradeId ");
			strSql.Append(" FROM Classes ");
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
			strSql.Append("select count(1) FROM Classes ");
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
				strSql.Append("order by T.GradeId desc");
			}
			strSql.Append(")AS Row, T.*  from Classes T ");
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
			parameters[0].Value = "Classes";
			parameters[1].Value = "GradeId";
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

