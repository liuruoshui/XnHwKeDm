using SXEdu2XHKD.Domain.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace SXEdu2XHKD.Domain.Concrete.DAL
{
    public partial class Pp22CourseView
    {
        public SXEdu2XHKD.Domain.Entities.Pp22CourseView GetModelByCode(string code)
        {
            //通过code获取CourseView实体
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,lx,mulu,LecURL,CourseCode,addtime,kejianlx,leibie,gradeid,courseclass from zz_Course_view ");
            strSql.Append(" where CourseCode=@CourseCode");
            SqlParameter[] parameters = {
                                            new SqlParameter("@CourseCode",SqlDbType.NVarChar)
                                        };
            parameters[0].Value = code;

            SXEdu2XHKD.Domain.Entities.Pp22CourseView model = new SXEdu2XHKD.Domain.Entities.Pp22CourseView();
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