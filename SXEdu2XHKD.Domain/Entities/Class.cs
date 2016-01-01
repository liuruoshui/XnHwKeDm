using System;
namespace SXEdu2XHKD.Domain.Entities
{
	/// <summary>
	/// Classes:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Class
	{
		public Class()
		{}
		#region Model
        public string ClassName{get;set;}
		public int SchoolId{get;set;}
		public int GradeId{get;set;}

		#endregion Model

	}
}

