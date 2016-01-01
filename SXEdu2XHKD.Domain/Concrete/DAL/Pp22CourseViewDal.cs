using SXEdu2XHKD.Domain.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Dapper;
namespace SXEdu2XHKD.Domain.Concrete.DAL
{
    public class Pp22CourseViewDal
    {
        public SXEdu2XHKD.Domain.Entities.Pp22CourseView GetModelByCode(string code)
        {
            using (IDbConnection conn = DapperHelper.ConnectToPp22())
            {
                StringBuilder queryStr = new StringBuilder();
                queryStr.Append("select * from zz_Course_view ");
                queryStr.Append(" where CourseCode=@CourseCode");
                return conn.Query<SXEdu2XHKD.Domain.Entities.Pp22CourseView>(queryStr.ToString(), new { CourseCode = code }).FirstOrDefault();
            }
        }
    }
}