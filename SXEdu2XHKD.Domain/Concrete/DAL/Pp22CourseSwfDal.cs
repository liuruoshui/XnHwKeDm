using SXEdu2XHKD.Domain.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Dapper;
namespace SXEdu2XHKD.Domain.Concrete.DAL
{
    public class Pp22CourseSwfDal
    {
        public SXEdu2XHKD.Domain.Entities.Pp22CourseSwf GetModel(int id)
        {
            using (IDbConnection conn = DapperHelper.ConnectToPp22())
            {
                StringBuilder queryStr=new StringBuilder();
			    queryStr.Append("select * from zz_course_swf ");
			    queryStr.Append(" where id=@id ");
                return conn.Query<SXEdu2XHKD.Domain.Entities.Pp22CourseSwf>(queryStr.ToString(), new { id = id }).FirstOrDefault();
            }
        }

        public IEnumerable<SXEdu2XHKD.Domain.Entities.Pp22CourseSwf> GetSwfListlByCode(string code)
        {
            using (IDbConnection conn = DapperHelper.ConnectToPp22())
            {

                StringBuilder queryStr = new StringBuilder();
                queryStr.Append("select * from zz_course_swf ");
                queryStr.Append(" where code=@code ");
                return conn.Query<SXEdu2XHKD.Domain.Entities.Pp22CourseSwf>(queryStr.ToString(), new { code = code });
            }
        }
    }
}
