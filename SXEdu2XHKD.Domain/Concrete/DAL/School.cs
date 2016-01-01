using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;
using SXEdu2XHKD.Domain.Common;//Please add references
namespace SXEdu2XHKD.Domain.Concrete.DAL
{
	/// <summary>
	/// 数据访问类:Schools
	/// </summary>
	public partial class School
	{
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelper.GetMaxID("SchoolId", "Schools"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int SchoolId)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Schools");
			strSql.Append(" where SchoolId=@SchoolId");
			SqlParameter[] parameters = {
					new SqlParameter("@SchoolId", SqlDbType.Int,4)
			};
			parameters[0].Value = SchoolId;

			return DbHelper.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(SXEdu2XHKD.Domain.Entities.School model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Schools(");
			strSql.Append("SchoolName)");
			strSql.Append(" values (");
			strSql.Append("@SchoolName)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@SchoolName", SqlDbType.NVarChar,50)};
			parameters[0].Value = model.SchoolName;

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
		public bool Update(SXEdu2XHKD.Domain.Entities.School model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Schools set ");
			strSql.Append("SchoolName=@SchoolName");
			strSql.Append(" where SchoolId=@SchoolId");
			SqlParameter[] parameters = {
					new SqlParameter("@SchoolName", SqlDbType.NVarChar,50),
					new SqlParameter("@SchoolId", SqlDbType.Int,4)};
			parameters[0].Value = model.SchoolName;
			parameters[1].Value = model.SchoolId;

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
		public bool Delete(int SchoolId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Schools ");
			strSql.Append(" where SchoolId=@SchoolId");
			SqlParameter[] parameters = {
					new SqlParameter("@SchoolId", SqlDbType.Int,4)
			};
			parameters[0].Value = SchoolId;

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
		public bool DeleteList(string SchoolIdlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Schools ");
			strSql.Append(" where SchoolId in ("+SchoolIdlist + ")  ");
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
		public SXEdu2XHKD.Domain.Entities.School GetModel(int SchoolId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 SchoolId,SchoolName from Schools ");
			strSql.Append(" where SchoolId=@SchoolId");
			SqlParameter[] parameters = {
					new SqlParameter("@SchoolId", SqlDbType.Int,4)
			};
			parameters[0].Value = SchoolId;

			SXEdu2XHKD.Domain.Entities.School model=new SXEdu2XHKD.Domain.Entities.School();
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
		public SXEdu2XHKD.Domain.Entities.School DataRowToModel(DataRow row)
		{
			SXEdu2XHKD.Domain.Entities.School model=new SXEdu2XHKD.Domain.Entities.School();
			if (row != null)
			{
				if(row["SchoolId"]!=null && row["SchoolId"].ToString()!="")
				{
					model.SchoolId=int.Parse(row["SchoolId"].ToString());
				}
				if(row["SchoolName"]!=null)
				{
					model.SchoolName=row["SchoolName"].ToString();
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
			strSql.Append("select SchoolId,SchoolName ");
			strSql.Append(" FROM Schools ");
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
			strSql.Append(" SchoolId,SchoolName ");
			strSql.Append(" FROM Schools ");
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
			strSql.Append("select count(1) FROM Schools ");
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
				strSql.Append("order by T.SchoolId desc");
			}
			strSql.Append(")AS Row, T.*  from Schools T ");
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
			parameters[0].Value = "Schools";
			parameters[1].Value = "SchoolId";
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

