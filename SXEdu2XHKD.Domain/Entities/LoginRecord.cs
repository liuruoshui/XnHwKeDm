using System;
namespace SXEdu2XHKD.Domain.Entities
{
	/// <summary>
	/// LoginRecords:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class LoginRecord
	{
		public LoginRecord()
		{}
		#region Model
        public int LoginRecordId;
        public DateTime LogInTime;
        public DateTime LogOutTime;
        public int MemberId;
        public string SXEduUserName;

		#endregion Model

	}
}

