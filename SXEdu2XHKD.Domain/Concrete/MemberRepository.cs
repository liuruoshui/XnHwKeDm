using System;
using System.Data;
using System.Collections.Generic;
using SXEdu2XHKD.Domain.Common;
using SXEdu2XHKD.Domain.Entities;

namespace SXEdu2XHKD.Domain.Concrete
{
	/// <summary>
	/// Members
	/// </summary>
    public partial class MemberRepository
	{
		private readonly SXEdu2XHKD.Domain.Concrete.DAL.Member dal=new SXEdu2XHKD.Domain.Concrete.DAL.Member();
		public MemberRepository()
		{}
		#region  BasicMethod

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(SXEdu2XHKD.Domain.Entities.Member model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(SXEdu2XHKD.Domain.Entities.Member model)
		{
			return dal.Update(model);
		}


		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}

		#endregion  BasicMethod
	}
}

