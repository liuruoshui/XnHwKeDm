using System;
using System.Data;
using System.Collections.Generic;
using SXEdu2XHKD.Domain.Entities;
using System.Linq;
namespace SXEdu2XHKD.Domain.Concrete
{
	/// <summary>
	/// LoginRecords
	/// </summary>
	public partial class LoginRecordRepository
	{
        private readonly SXEdu2XHKD.Domain.Concrete.DAL.LoginRecordDal dal = new SXEdu2XHKD.Domain.Concrete.DAL.LoginRecordDal();

		#region  BasicMethod
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(SXEdu2XHKD.Domain.Entities.LoginRecord model)
		{
			return dal.Add(model);
		}

        /// <summary>
        /// 根据日期获取登陆记录
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public List<SXEdu2XHKD.Domain.Entities.LoginRecord> GetLoginRecordByDate(DateTime date)
        {
            return dal.GetLoginRecordByDate(date).ToList();
        }
		#endregion  BasicMethod
	}
}