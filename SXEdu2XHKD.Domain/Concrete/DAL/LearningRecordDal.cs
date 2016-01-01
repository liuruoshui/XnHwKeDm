using SXEdu2XHKD.Domain.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Dapper;

namespace SXEdu2XHKD.Domain.Concrete.DAL
{
    public class LearningRecordDal
    {
        public LearningRecordDal()
        { }
        #region  BasicMethod
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(SXEdu2XHKD.Domain.Entities.LearningRecord learningRecord)
        {
            using (IDbConnection conn = DapperHelper.ConnectToSxEdu())
            {
                StringBuilder queryStr = new StringBuilder();
                queryStr.Append("insert into LearningRecords(");
                queryStr.Append("MemberId,CourseCode,RecordTime,SXEduUserName)");
                queryStr.Append(" values (");
                queryStr.Append("@MemberId,@CourseCode,@RecordTime,@SXEduUserName);");
                return conn.Execute(queryStr.ToString(), learningRecord);
            }
        }
        #endregion  BasicMethod
        public IEnumerable<SXEdu2XHKD.Domain.Entities.LearningRecord> GetLearningRecordByDate(DateTime date)
        {
            using (IDbConnection conn = DapperHelper.ConnectToSxEdu())
            {
                StringBuilder queryStr = new StringBuilder();
                queryStr.Append("select * from LearningRecords ");

                queryStr.Append(" where RecordTime between @DateStart and @DateEnd");
                DateTime dateStart = date;
                DateTime dateEnd = date.AddDays(1);

                return conn.Query<SXEdu2XHKD.Domain.Entities.LearningRecord>(queryStr.ToString(), new { DateStart = dateStart, DateEnd = dateEnd });
            }
        }
    }
}
