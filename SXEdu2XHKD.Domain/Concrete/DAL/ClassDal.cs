using SXEdu2XHKD.Domain.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Dapper;
namespace SXEdu2XHKD.Domain.Concrete.DAL
{
    public class ClassDal
    {

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string ClassName, int SchoolId, int GradeId)
        {
            using (IDbConnection conn = DapperHelper.ConnectToSxEdu())
            {
                StringBuilder queryStr = new StringBuilder();
                queryStr.Append("select * from Classes");
                queryStr.Append(" where ClassName=@ClassName and SchoolId=@SchoolId and GradeId=@GradeId ");
                IEnumerable<SXEdu2XHKD.Domain.Entities.Class> classes = conn.Query<SXEdu2XHKD.Domain.Entities.Class>(queryStr.ToString(),
                    new { ClassName = ClassName, SchoolId = SchoolId, GradeId = GradeId });
                return classes.Count() > 0;
            }
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(SXEdu2XHKD.Domain.Entities.Class classModel)
        {
            using (IDbConnection conn = DapperHelper.ConnectToSxEdu())
            {
                StringBuilder queryStr = new StringBuilder();
                queryStr.Append("insert into Classes(");
                queryStr.Append("ClassName,SchoolId,GradeId)");
                queryStr.Append(" values (");
                queryStr.Append("@ClassName,@SchoolId,@GradeId);");
                int count = conn.Execute(queryStr.ToString(), classModel);
                return count > 0;
            }
        }

    }
}
