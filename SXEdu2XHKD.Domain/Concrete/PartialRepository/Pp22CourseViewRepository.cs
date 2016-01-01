using SXEdu2XHKD.Domain.Common;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace SXEdu2XHKD.Domain.Concrete
{
    public partial class Pp22CourseViewRepository
    {
        public Pp22CourseViewRepository()
        {
            DbHelper.connectionString = ConfigurationManager.AppSettings["ConnectionStringpp22"];
        }

        public SXEdu2XHKD.Domain.Entities.Pp22CourseView GetModelByCode(string code)
        {
            Pp22CourseSwfRepository pp22CourseSwfRepository = new Pp22CourseSwfRepository();
            SXEdu2XHKD.Domain.Entities.Pp22CourseView pp22CourseView = dal.GetModelByCode(code);
            if (pp22CourseView != null)
            {
                pp22CourseView.Pp22CourseSwfs = pp22CourseSwfRepository.GetSwfListlByCode(code);
            }
            return pp22CourseView;
        }
    }
}