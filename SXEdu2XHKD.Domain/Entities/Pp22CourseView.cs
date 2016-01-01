using System;
using System.Collections.Generic;
namespace SXEdu2XHKD.Domain.Entities
{
	/// <summary>
	/// 1
	/// </summary>
	[Serializable]
	public partial class Pp22CourseView
	{
        public Pp22CourseView()
		{}
		#region Model
        public int id{get;set;}
        public string lx{get;set;}
        public string mulu{get;set;}
        public string LecURL{get;set;}
        public string CourseCode{get;set;}
        public DateTime? addtime{get;set;}
        public int? kejianlx{get;set;}
        public int? leibie{get;set;}
        public int? gradeid{get;set;}
        public string courseclass{get;set;}
		#endregion Model
        public IEnumerable<Pp22CourseSwf> Pp22CourseSwfs { get; set; }
	}
}

