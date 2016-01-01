using System;
namespace SXEdu2XHKD.Domain.Entities
{
	/// <summary>
	/// LearningRecords:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class LearningRecord
	{
		public LearningRecord()
		{}
		#region Model
        public int LearningRecordId{get;set;}
		public int MemberId{get;set;}
		public string CourseCode{get;set;}
		public DateTime RecordTime{get;set;}
		public string SxEduUserName{get;set;}

		#endregion Model

	}
}

