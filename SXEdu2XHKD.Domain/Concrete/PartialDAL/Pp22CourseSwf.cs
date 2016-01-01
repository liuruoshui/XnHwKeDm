using SXEdu2XHKD.Domain.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace SXEdu2XHKD.Domain.Concrete.DAL
{
    public partial class Pp22CourseSwf
    {
        /// <summary>
        /// 通过Code获得CourseSwf列表
        /// </summary>
        public List<SXEdu2XHKD.Domain.Entities.Pp22CourseSwf> GetSwfListlByCode(string code)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,code,mulu,swf,addtime from zz_course_swf ");
            strSql.Append(" where code=@code ");
            SqlParameter[] parameters = {
                                            new SqlParameter("@code", SqlDbType.NVarChar)
                                        };
            parameters[0].Value = code;

            //SXEdu2XHKD.Domain.Entities.Pp22CourseSwf model = new SXEdu2XHKD.Domain.Entities.Pp22CourseSwf();
            DataSet ds = DbHelper.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                List<SXEdu2XHKD.Domain.Entities.Pp22CourseSwf> courseSwfList = new List<Entities.Pp22CourseSwf>();
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    courseSwfList.Add(DataRowToModel(row));
                }
                return courseSwfList;
            }
            else
            {
                return null;
            }
        }
    }
}
