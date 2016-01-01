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
		private readonly SXEdu2XHKD.Domain.Concrete.DAL.School dal=new SXEdu2XHKD.Domain.Concrete.DAL.School();
		public SchoolRepository()
		{}
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
		public bool Exists(int SchoolId)
		{
			return dal.Exists(SchoolId);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(SXEdu2XHKD.Domain.Entities.School model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(SXEdu2XHKD.Domain.Entities.School model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int SchoolId)
		{
			
			return dal.Delete(SchoolId);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string SchoolIdlist )
		{
			return dal.DeleteList(SXEdu2XHKD.Domain.Common.PageValidate.SafeLongFilter(SchoolIdlist,0) );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public SXEdu2XHKD.Domain.Entities.School  GetModel(int SchoolId)
		{
			return dal.GetModel(SchoolId);
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
		public List<SXEdu2XHKD.Domain.Entities.School> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<SXEdu2XHKD.Domain.Entities.School> DataTableToList(DataTable dt)
		{
			List<SXEdu2XHKD.Domain.Entities.School> modelList = new List<SXEdu2XHKD.Domain.Entities.School>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				SXEdu2XHKD.Domain.Entities.School model;
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

