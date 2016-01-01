using System;
using System.ComponentModel;
namespace SXEdu2XHKD.Domain.Entities
{
	/// <summary>
	/// Member:对应数据库中的Members表，为会员信息类
	/// </summary>
	[Serializable]
	public partial class Member
	{
		public Member()
		{}
		#region Model
        public int MemberId{get;set;}
        public string SxEduUserInfo{get;set;}
        public string SXEduUserName{get;set;}
        public int? School{get;set;}
        public int Grade{get;set;}
        public string ClassName{get;set;}
        public string UserName{get;set;}
        public string PassWord{get;set;}
        public DateTime? BirthDay{get;set;}
        public string Email{get;set;}
        public string Name{get;set;}
        public DateTime RegisterTime{get;set;}
        public string QQ{get;set;}
        public int? UserType{get;set;}
        public string ParentName{get;set;}
        public int? UserStatus{get;set;}
		#endregion Model
        public School SchoolEntity { get; set; }
	}
}

