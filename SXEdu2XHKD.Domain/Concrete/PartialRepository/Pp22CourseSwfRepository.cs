using SXEdu2XHKD.Domain.Common;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace SXEdu2XHKD.Domain.Concrete
{
    public partial class Pp22CourseSwfRepository
    {
        public Pp22CourseSwfRepository()
        {
            DbHelper.connectionString = ConfigurationManager.AppSettings["ConnectionStringpp22"];
        }

        public List<SXEdu2XHKD.Domain.Entities.Pp22CourseSwf> GetSwfListlByCode(string code)
        {
            return dal.GetSwfListlByCode(code);
        }
    }
}
