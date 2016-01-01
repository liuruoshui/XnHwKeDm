using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;
using SXEdu2XHKD.Domain.Common;//Please add references
namespace SXEdu2XHKD.Domain.Concrete.DAL
{
	/// <summary>
	/// 数据访问类:zz_Course_view
	/// </summary>
	public partial class Pp22CourseView
	{
        public Pp22CourseView()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public SXEdu2XHKD.Domain.Entities.Pp22CourseView DataRowToModel(DataRow row)
		{
			SXEdu2XHKD.Domain.Entities.Pp22CourseView model=new SXEdu2XHKD.Domain.Entities.Pp22CourseView();
			if (row != null)
			{
				if(row["id"]!=null && row["id"].ToString()!="")
				{
					model.id=int.Parse(row["id"].ToString());
				}
				if(row["lx"]!=null)
				{
					model.lx=row["lx"].ToString();
				}
				if(row["mulu"]!=null)
				{
					model.mulu=row["mulu"].ToString();
				}
				if(row["LecURL"]!=null)
				{
					model.LecURL=row["LecURL"].ToString();
				}
				if(row["CourseCode"]!=null)
				{
					model.CourseCode=row["CourseCode"].ToString();
				}
				if(row["addtime"]!=null && row["addtime"].ToString()!="")
				{
					model.addtime=DateTime.Parse(row["addtime"].ToString());
				}
				if(row["kejianlx"]!=null && row["kejianlx"].ToString()!="")
				{
					model.kejianlx=int.Parse(row["kejianlx"].ToString());
				}
				if(row["leibie"]!=null && row["leibie"].ToString()!="")
				{
					model.leibie=int.Parse(row["leibie"].ToString());
				}
				if(row["gradeid"]!=null && row["gradeid"].ToString()!="")
				{
					model.gradeid=int.Parse(row["gradeid"].ToString());
				}
				if(row["courseclass"]!=null)
				{
					model.courseclass=row["courseclass"].ToString();
				}
			}
			return model;
		}

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

