using SXEdu2XHKD.Domain.Common;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace SXEdu2XHKD.Domain.Concrete
{
    partial class LoginRecordRepository
    {
        public LoginRecordRepository()
        {
            DbHelper.connectionString = ConfigurationManager.AppSettings["ConnectionStringSXEdu"];
        }

        public List<SXEdu2XHKD.Domain.Entities.LoginRecord> GetLoginRecordByDate(DateTime date)
        {
            return dal.GetLoginRecordByDate(date);
        }
    }
}
