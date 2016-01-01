using System;
using System.Data;
using System.Collections.Generic;
using SXEdu2XHKD.Domain.Common;
using SXEdu2XHKD.Domain.Entities;
namespace SXEdu2XHKD.Domain.BLL
{
	/// <summary>
	/// Classes
	/// </summary>
	public partial class ClassRepository
	{
        private readonly SXEdu2XHKD.Domain.Concrete.DAL.ClassDal dal = new SXEdu2XHKD.Domain.Concrete.DAL.ClassDal();
        public ClassRepository()
		{}
		#region  BasicMethod


		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string ClassName,int SchoolId,int GradeId)
		{
			return dal.Exists(ClassName,SchoolId,GradeId);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(SXEdu2XHKD.Domain.Entities.Class model)
		{
			return dal.Add(model);
		}

		#endregion  BasicMethod
	}
}

