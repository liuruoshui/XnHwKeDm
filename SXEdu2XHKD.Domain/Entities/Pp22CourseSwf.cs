using System;
namespace SXEdu2XHKD.Domain.Entities
{
	/// <summary>
	/// 1
	/// </summary>
	[Serializable]
    public partial class Pp22CourseSwf
	{
        public Pp22CourseSwf()
		{}
		#region Model
        public int id{get;set;}
        public string code{get;set;}
        public string mulu{get;set;}
        public string swf{get;set;}
        public DateTime? addtime{get;set;}
		#endregion Model

	}
}

