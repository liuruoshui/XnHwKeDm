using System;
using System.Data;
using System.Collections.Generic;
using SXEdu2XHKD.Domain.Entities;
using System.Linq;

namespace SXEdu2XHKD.Domain.Concrete
{
	/// <summary>
	/// 1
	/// </summary>
	public partial class Pp22CourseSwfRepository
	{
        private readonly SXEdu2XHKD.Domain.Concrete.DAL.Pp22CourseSwfDal dal = new SXEdu2XHKD.Domain.Concrete.DAL.Pp22CourseSwfDal();

		#region  BasicMethod

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public SXEdu2XHKD.Domain.Entities.Pp22CourseSwf GetModel(int id)
		{
			
			return dal.GetModel(id);
		}

        public Pp22CourseSwfRepository()
        {
        }

        public IEnumerable<SXEdu2XHKD.Domain.Entities.Pp22CourseSwf> GetSwfListlByCode(string code)
        {
            return dal.GetSwfListlByCode(code);
        }
		#endregion  BasicMethod
	}
}

