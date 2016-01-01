using System;
using System.Data;
using System.Collections.Generic;
using SXEdu2XHKD.Domain.Common;
using SXEdu2XHKD.Domain.Entities;
using System.Linq;
namespace SXEdu2XHKD.Domain.Concrete
{
	/// <summary>
	/// LearningRecords
	/// </summary>
	public partial class LearningRecordRepository
	{
		private readonly SXEdu2XHKD.Domain.Concrete.DAL.LearningRecordDal dal=new SXEdu2XHKD.Domain.Concrete.DAL.LearningRecordDal();

		#region  BasicMethod
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(SXEdu2XHKD.Domain.Entities.LearningRecord model)
		{
			return dal.Add(model);
		}
		#endregion  BasicMethod

        /// <summary>
        /// 根据日期获取上课记录
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public List<SXEdu2XHKD.Domain.Entities.LearningRecord> GetLearningRecordByDate(DateTime date)
        {
            return dal.GetLearningRecordByDate(date).ToList();
        }
	}
}

