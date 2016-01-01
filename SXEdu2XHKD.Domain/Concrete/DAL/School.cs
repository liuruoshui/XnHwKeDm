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

		#endregion  BasicMethod


        /// <summary>
        /// 判断某个学校是否存在
        /// </summary>
        /// <param name="name">学校名</param>
        /// <returns></returns>
        public bool SchoolNameExists(string schoolName)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Schools");
            strSql.Append(" where SchoolName=@SchoolName ");
            SqlParameter[] parameters = {
					new SqlParameter("@SchoolName", SqlDbType.NVarChar)};
            parameters[0].Value = schoolName;

            return DbHelper.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 根据学校名获取学校对象
        /// </summary>
        /// <param name="name">学校名</param>
        /// <returns></returns>
        public SXEdu2XHKD.Domain.Entities.School GetModelBySchoolName(string schoolName)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 SchoolId,SchoolName from Schools ");
            strSql.Append(" where SchoolName=@SchoolName ");
            SqlParameter[] parameters = {
					new SqlParameter("@SchoolName", SqlDbType.NVarChar)			};
            parameters[0].Value = schoolName;

            //SXEdu2XHKD.Domain.Entities.School model = new SXEdu2XHKD.Domain.Entities.School();
            DataSet ds = DbHelper.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return DataRowToModel(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }
	}
}

