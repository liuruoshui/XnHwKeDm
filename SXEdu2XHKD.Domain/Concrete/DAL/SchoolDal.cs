using SXEdu2XHKD.Domain.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Dapper;
namespace SXEdu2XHKD.Domain.Concrete.DAL
{
    public class SchoolDal
    {

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(SXEdu2XHKD.Domain.Entities.School school)
        {
            using (IDbConnection conn = DapperHelper.ConnectToSxEdu())
            {
                StringBuilder queryStr = new StringBuilder();
                queryStr.Append("insert into Schools(");
                queryStr.Append("SchoolName)");
                queryStr.Append(" values (");
                queryStr.Append("@SchoolName);");
                return conn.Execute(queryStr.ToString(), school);
            }
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public SXEdu2XHKD.Domain.Entities.School GetModel(int SchoolId)
        {
            using (IDbConnection conn = DapperHelper.ConnectToSxEdu())
            {
                StringBuilder queryStr = new StringBuilder();
                queryStr.Append("select * from Schools ");
                queryStr.Append(" where SchoolId=@SchoolId");
                return conn.Query<SXEdu2XHKD.Domain.Entities.School>(queryStr.ToString(), new { SchoolId = SchoolId }).FirstOrDefault();
            }
        }

        /// <summary>
        /// 判断某个学校是否存在
        /// </summary>
        /// <param name="name">学校名</param>
        /// <returns></returns>
        public bool SchoolNameExists(string schoolName)
        {
            using (IDbConnection conn = DapperHelper.ConnectToSxEdu())
            {
                StringBuilder queryStr = new StringBuilder();
                queryStr.Append("select * from Schools");
                queryStr.Append(" where SchoolName=@SchoolName ");
                IEnumerable<SXEdu2XHKD.Domain.Entities.School> schools = conn.Query<SXEdu2XHKD.Domain.Entities.School>(queryStr.ToString(),
                    new { SchoolName = schoolName });
                return schools.Count() > 0;
            }
        }

        /// <summary>
        /// 根据学校名获取学校对象
        /// </summary>
        /// <param name="name">学校名</param>
        /// <returns></returns>
        public SXEdu2XHKD.Domain.Entities.School GetModelBySchoolName(string schoolName)
        {
            using (IDbConnection conn = DapperHelper.ConnectToSxEdu())
            {
                StringBuilder queryStr = new StringBuilder();
                queryStr.Append("select * from Schools ");
                queryStr.Append(" where SchoolName=@SchoolName ");
                return conn.Query<SXEdu2XHKD.Domain.Entities.School>(queryStr.ToString(), new { SchoolName = schoolName }).FirstOrDefault();
            }
        }
    }
}
