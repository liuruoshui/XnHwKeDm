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
		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

