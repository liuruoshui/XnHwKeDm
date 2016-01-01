using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;
using SXEdu2XHKD.Domain.Common;//Please add references
namespace SXEdu2XHKD.Domain.Concrete.DAL
{
	/// <summary>
	/// 数据访问类:zz_Course_view
	/// </summary>
	public partial class Pp22CourseView
	{
        public Pp22CourseView()
		{}
		#region  BasicMethod

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(SXEdu2XHKD.Domain.Entities.Pp22CourseView model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into zz_Course_view(");
			strSql.Append("id,lx,mulu,LecURL,CourseCode,addtime,kejianlx,leibie,gradeid,courseclass)");
			strSql.Append(" values (");
			strSql.Append("@id,@lx,@mulu,@LecURL,@CourseCode,@addtime,@kejianlx,@leibie,@gradeid,@courseclass)");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4),
					new SqlParameter("@lx", SqlDbType.VarChar,1),
					new SqlParameter("@mulu", SqlDbType.NVarChar,50),
					new SqlParameter("@LecURL", SqlDbType.NVarChar,200),
					new SqlParameter("@CourseCode", SqlDbType.NVarChar,200),
					new SqlParameter("@addtime", SqlDbType.DateTime),
					new SqlParameter("@kejianlx", SqlDbType.Int,4),
					new SqlParameter("@leibie", SqlDbType.Int,4),
					new SqlParameter("@gradeid", SqlDbType.Int,4),
					new SqlParameter("@courseclass", SqlDbType.NVarChar,200)};
			parameters[0].Value = model.id;
			parameters[1].Value = model.lx;
			parameters[2].Value = model.mulu;
			parameters[3].Value = model.LecURL;
			parameters[4].Value = model.CourseCode;
			parameters[5].Value = model.addtime;
			parameters[6].Value = model.kejianlx;
			parameters[7].Value = model.leibie;
			parameters[8].Value = model.gradeid;
			parameters[9].Value = model.courseclass;

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
		public bool Update(SXEdu2XHKD.Domain.Entities.Pp22CourseView model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update zz_Course_view set ");
			strSql.Append("id=@id,");
			strSql.Append("lx=@lx,");
			strSql.Append("mulu=@mulu,");
			strSql.Append("LecURL=@LecURL,");
			strSql.Append("CourseCode=@CourseCode,");
			strSql.Append("addtime=@addtime,");
			strSql.Append("kejianlx=@kejianlx,");
			strSql.Append("leibie=@leibie,");
			strSql.Append("gradeid=@gradeid,");
			strSql.Append("courseclass=@courseclass");
			strSql.Append(" where ");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4),
					new SqlParameter("@lx", SqlDbType.VarChar,1),
					new SqlParameter("@mulu", SqlDbType.NVarChar,50),
					new SqlParameter("@LecURL", SqlDbType.NVarChar,200),
					new SqlParameter("@CourseCode", SqlDbType.NVarChar,200),
					new SqlParameter("@addtime", SqlDbType.DateTime),
					new SqlParameter("@kejianlx", SqlDbType.Int,4),
					new SqlParameter("@leibie", SqlDbType.Int,4),
					new SqlParameter("@gradeid", SqlDbType.Int,4),
					new SqlParameter("@courseclass", SqlDbType.NVarChar,200)};
			parameters[0].Value = model.id;
			parameters[1].Value = model.lx;
			parameters[2].Value = model.mulu;
			parameters[3].Value = model.LecURL;
			parameters[4].Value = model.CourseCode;
			parameters[5].Value = model.addtime;
			parameters[6].Value = model.kejianlx;
			parameters[7].Value = model.leibie;
			parameters[8].Value = model.gradeid;
			parameters[9].Value = model.courseclass;

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
		public bool Delete()
		{
			//该表无主键信息，请自定义主键/条件字段
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from zz_Course_view ");
			strSql.Append(" where ");
			SqlParameter[] parameters = {
			};

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
		public SXEdu2XHKD.Domain.Entities.Pp22CourseView GetModel()
		{
			//该表无主键信息，请自定义主键/条件字段
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,lx,mulu,LecURL,CourseCode,addtime,kejianlx,leibie,gradeid,courseclass from zz_Course_view ");
			strSql.Append(" where ");
			SqlParameter[] parameters = {
			};

			SXEdu2XHKD.Domain.Entities.Pp22CourseView model=new SXEdu2XHKD.Domain.Entities.Pp22CourseView();
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
		public SXEdu2XHKD.Domain.Entities.Pp22CourseView DataRowToModel(DataRow row)
		{
			SXEdu2XHKD.Domain.Entities.Pp22CourseView model=new SXEdu2XHKD.Domain.Entities.Pp22CourseView();
			if (row != null)
			{
				if(row["id"]!=null && row["id"].ToString()!="")
				{
					model.id=int.Parse(row["id"].ToString());
				}
				if(row["lx"]!=null)
				{
					model.lx=row["lx"].ToString();
				}
				if(row["mulu"]!=null)
				{
					model.mulu=row["mulu"].ToString();
				}
				if(row["LecURL"]!=null)
				{
					model.LecURL=row["LecURL"].ToString();
				}
				if(row["CourseCode"]!=null)
				{
					model.CourseCode=row["CourseCode"].ToString();
				}
				if(row["addtime"]!=null && row["addtime"].ToString()!="")
				{
					model.addtime=DateTime.Parse(row["addtime"].ToString());
				}
				if(row["kejianlx"]!=null && row["kejianlx"].ToString()!="")
				{
					model.kejianlx=int.Parse(row["kejianlx"].ToString());
				}
				if(row["leibie"]!=null && row["leibie"].ToString()!="")
				{
					model.leibie=int.Parse(row["leibie"].ToString());
				}
				if(row["gradeid"]!=null && row["gradeid"].ToString()!="")
				{
					model.gradeid=int.Parse(row["gradeid"].ToString());
				}
				if(row["courseclass"]!=null)
				{
					model.courseclass=row["courseclass"].ToString();
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
			strSql.Append("select id,lx,mulu,LecURL,CourseCode,addtime,kejianlx,leibie,gradeid,courseclass ");
			strSql.Append(" FROM zz_Course_view ");
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
			strSql.Append(" id,lx,mulu,LecURL,CourseCode,addtime,kejianlx,leibie,gradeid,courseclass ");
			strSql.Append(" FROM zz_Course_view ");
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
			strSql.Append("select count(1) FROM zz_Course_view ");
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
			strSql.Append(")AS Row, T.*  from zz_Course_view T ");
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
			parameters[0].Value = "zz_Course_view";
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

