using System;
using System.Data;
using System.Collections.Generic;


namespace SXEdu2XHKD.Domain.Concrete
{
	/// <summary>
	/// Schools
	/// </summary>
	public partial class SchoolRepository
	{
        private readonly SXEdu2XHKD.Domain.Concrete.DAL.SchoolDal dal = new SXEdu2XHKD.Domain.Concrete.DAL.SchoolDal();
		public SchoolRepository()
		{}
		#region  BasicMethod

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(SXEdu2XHKD.Domain.Entities.School model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public SXEdu2XHKD.Domain.Entities.School  GetModel(int SchoolId)
		{
			return dal.GetModel(SchoolId);
		}
		#endregion  BasicMethod

        public SXEdu2XHKD.Domain.Entities.School GetModelBySchoolName(string schoolName)
        {
            return dal.GetModelBySchoolName(schoolName);
        }

        public bool SchoolNameExists(string schoolName)
        {
            return dal.SchoolNameExists(schoolName);
        }
	}
}

