using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using SXEdu2XHKD.Domain.Common;//Please add references
namespace SXEdu2XHKD.Domain.Concrete.DAL
{
	/// <summary>
	/// 数据访问类:zz_course_swf
	/// </summary>
	public partial class Pp22CourseSwf
	{
        public Pp22CourseSwf()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelper.GetMaxID("id", "zz_course_swf"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from zz_course_swf");
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)			};
			parameters[0].Value = id;

			return DbHelper.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(SXEdu2XHKD.Domain.Entities.Pp22CourseSwf model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into zz_course_swf(");
			strSql.Append("id,code,mulu,swf,addtime)");
			strSql.Append(" values (");
			strSql.Append("@id,@code,@mulu,@swf,@addtime)");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4),
					new SqlParameter("@code", SqlDbType.NVarChar,50),
					new SqlParameter("@mulu", SqlDbType.NVarChar,200),
					new SqlParameter("@swf", SqlDbType.NVarChar,200),
					new SqlParameter("@addtime", SqlDbType.DateTime)};
			parameters[0].Value = model.id;
			parameters[1].Value = model.code;
			parameters[2].Value = model.mulu;
			parameters[3].Value = model.swf;
			parameters[4].Value = model.addtime;

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
		public bool Update(SXEdu2XHKD.Domain.Entities.Pp22CourseSwf model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update zz_course_swf set ");
			strSql.Append("code=@code,");
			strSql.Append("mulu=@mulu,");
			strSql.Append("swf=@swf,");
			strSql.Append("addtime=@addtime");
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@code", SqlDbType.NVarChar,50),
					new SqlParameter("@mulu", SqlDbType.NVarChar,200),
					new SqlParameter("@swf", SqlDbType.NVarChar,200),
					new SqlParameter("@addtime", SqlDbType.DateTime),
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = model.code;
			parameters[1].Value = model.mulu;
			parameters[2].Value = model.swf;
			parameters[3].Value = model.addtime;
			parameters[4].Value = model.id;

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
		public bool Delete(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from zz_course_swf ");
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)			};
			parameters[0].Value = id;

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
		public bool DeleteList(string idlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from zz_course_swf ");
			strSql.Append(" where id in ("+idlist + ")  ");
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
		public SXEdu2XHKD.Domain.Entities.Pp22CourseSwf GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,code,mulu,swf,addtime from zz_course_swf ");
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)			};
			parameters[0].Value = id;

			SXEdu2XHKD.Domain.Entities.Pp22CourseSwf model=new SXEdu2XHKD.Domain.Entities.Pp22CourseSwf();
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
		public SXEdu2XHKD.Domain.Entities.Pp22CourseSwf DataRowToModel(DataRow row)
		{
			SXEdu2XHKD.Domain.Entities.Pp22CourseSwf model=new SXEdu2XHKD.Domain.Entities.Pp22CourseSwf();
			if (row != null)
			{
				if(row["id"]!=null && row["id"].ToString()!="")
				{
					model.id=int.Parse(row["id"].ToString());
				}
				if(row["code"]!=null)
				{
					model.code=row["code"].ToString();
				}
				if(row["mulu"]!=null)
				{
					model.mulu=row["mulu"].ToString();
				}
				if(row["swf"]!=null)
				{
					model.swf=row["swf"].ToString();
				}
				if(row["addtime"]!=null && row["addtime"].ToString()!="")
				{
					model.addtime=DateTime.Parse(row["addtime"].ToString());
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
			strSql.Append("select id,code,mulu,swf,addtime ");
			strSql.Append(" FROM zz_course_swf ");
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
			strSql.Append(" id,code,mulu,swf,addtime ");
			strSql.Append(" FROM zz_course_swf ");
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
			strSql.Append("select count(1) FROM zz_course_swf ");
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
				strSql.Append("order by T.id desc");
			}
			strSql.Append(")AS Row, T.*  from zz_course_swf T ");
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
			parameters[0].Value = "zz_course_swf";
			parameters[1].Value = "id";
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

