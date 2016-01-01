using System;
using System.Data;
using System.Collections.Generic;
using SXEdu2XHKD.Domain.Entities;
namespace SXEdu2XHKD.Domain.Concrete
{
	/// <summary>
	/// LoginRecords
	/// </summary>
	public partial class LoginRecordRepository
	{
		private readonly SXEdu2XHKD.Domain.Concrete.DAL.LoginRecord dal=new SXEdu2XHKD.Domain.Concrete.DAL.LoginRecord();

		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
			return dal.GetMaxId();
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int LoginRecordId)
		{
			return dal.Exists(LoginRecordId);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(SXEdu2XHKD.Domain.Entities.LoginRecord model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(SXEdu2XHKD.Domain.Entities.LoginRecord model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int LoginRecordId)
		{
			
			return dal.Delete(LoginRecordId);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string LoginRecordIdlist )
		{
			return dal.DeleteList(SXEdu2XHKD.Domain.Common.PageValidate.SafeLongFilter(LoginRecordIdlist,0) );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public SXEdu2XHKD.Domain.Entities.LoginRecord GetModel(int LoginRecordId)
		{
			
			return dal.GetModel(LoginRecordId);
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}
		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			return dal.GetList(Top,strWhere,filedOrder);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<SXEdu2XHKD.Domain.Entities.LoginRecord> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<SXEdu2XHKD.Domain.Entities.LoginRecord> DataTableToList(DataTable dt)
		{
			List<SXEdu2XHKD.Domain.Entities.LoginRecord> modelList = new List<SXEdu2XHKD.Domain.Entities.LoginRecord>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				SXEdu2XHKD.Domain.Entities.LoginRecord model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = dal.DataRowToModel(dt.Rows[n]);
					if (model != null)
					{
						modelList.Add(model);
					}
				}
			}
			return modelList;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetAllList()
		{
			return GetList("");
		}

		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			return dal.GetRecordCount(strWhere);
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			return dal.GetListByPage( strWhere,  orderby,  startIndex,  endIndex);
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		//public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		//{
			//return dal.GetList(PageSize,PageIndex,strWhere);
		//}

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

