using SXEdu2XHKD.Domain.Common;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace SXEdu2XHKD.Domain.Concrete
{
    public partial class LearningRecordRepository
    {
        public LearningRecordRepository()
        {
            DbHelper.connectionString = ConfigurationManager.AppSettings["ConnectionStringSXEdu"];
        }
    }
}
