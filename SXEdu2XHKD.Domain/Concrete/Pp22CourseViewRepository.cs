using System;
using System.Data;
using System.Collections.Generic;
using SXEdu2XHKD.Domain.Entities;
namespace SXEdu2XHKD.Domain.Concrete
{
	/// <summary>
	/// 1
	/// </summary>
	public partial class Pp22CourseViewRepository
	{
        private readonly SXEdu2XHKD.Domain.Concrete.DAL.Pp22CourseViewDal dal = new SXEdu2XHKD.Domain.Concrete.DAL.Pp22CourseViewDal();

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

