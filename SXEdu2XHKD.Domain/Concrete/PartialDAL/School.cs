using SXEdu2XHKD.Domain.Common;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SXEdu2XHKD.Domain.Concrete.DAL
{
    public partial class School
    {
        public School()
        {
            DbHelper.connectionString = ConfigurationManager.AppSettings["ConnectionStringSXEdu"];
        }

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
