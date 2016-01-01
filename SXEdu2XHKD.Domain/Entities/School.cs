using System;
using System.ComponentModel;
namespace SXEdu2XHKD.Domain.Entities
{
	/// <summary>
	/// Schools:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class School
	{
		public School()
		{}
		#region Model
        public int SchoolId { get; set; }
        [DisplayName("学校名称")]
        public string SchoolName { get; set; }
		#endregion Model

	}
}

