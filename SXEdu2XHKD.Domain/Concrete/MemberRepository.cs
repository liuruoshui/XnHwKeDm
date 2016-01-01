using System;
using System.Data;
using System.Collections.Generic;
using SXEdu2XHKD.Domain.Common;
using SXEdu2XHKD.Domain.Entities;
using SXEdu2XHKD.Domain.BLL;
using System.Linq;
namespace SXEdu2XHKD.Domain.Concrete
{
	/// <summary>
	/// Members
	/// </summary>
    public partial class MemberRepository
	{
        private readonly SXEdu2XHKD.Domain.Concrete.DAL.MemberDal dal = new SXEdu2XHKD.Domain.Concrete.DAL.MemberDal();
		public MemberRepository()
		{}
		#region  BasicMethod
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(SXEdu2XHKD.Domain.Entities.Member model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(SXEdu2XHKD.Domain.Entities.Member model)
		{
			return dal.Update(model);
		}

		#endregion  BasicMethod


        public SXEdu2XHKD.Domain.Entities.Member GetModelByName(string name)
        {
            return dal.GetModelByName(name);
        }

        public SXEdu2XHKD.Domain.Entities.Member GetModelBySXEduUserName(string name)
        {

            return dal.GetModelBySXEduUserName(name);
        }

        public SXEdu2XHKD.Domain.Entities.Member TransferMemberFromSXEduUserInfo(SXEduUserInfo sxEduUserInfo)
        {
            Member member = new Member()
            {
                UserName = sxEduUserInfo.NickName,
                Name = sxEduUserInfo.UserName,
                Grade = int.Parse(sxEduUserInfo.GradeId),
                Email = sxEduUserInfo.Email,
                SXEduUserName = sxEduUserInfo.NickName,
                ClassName = sxEduUserInfo.ClassName,
                UserType = int.Parse(sxEduUserInfo.UserType),
                SchoolEntity = new School { SchoolName = sxEduUserInfo.SchoolName }
            };
            return member;
        }

        /// <summary>
        /// 自定义添加Member,同时会验证School与Class是否存在而确定添加School和Class
        /// </summary>
        /// <param name="member"></param>
        /// <returns></returns>
        public int AddNewMember(Member member)
        {
            //检测school名字是否存在，如果存在，则将member.school存为school.Id
            //否则在表中插入新school数据，并将新数据的id赋值给school.Id
            SchoolRepository schoolRepository = new SchoolRepository();
            if (schoolRepository.SchoolNameExists(member.SchoolEntity.SchoolName))
            {
                member.School = schoolRepository.GetModelBySchoolName(member.SchoolEntity.SchoolName).SchoolId;
            }
            else
            {

                School school = member.SchoolEntity;
                schoolRepository.Add(school);
                member.School = schoolRepository.GetModelBySchoolName(school.SchoolName).SchoolId;
            }

            //检测Class名字是否存在，如果不存在,在class表中添加数据
            ClassRepository classRepository = new ClassRepository();
            if (!classRepository.Exists(member.ClassName, (int)member.School, (int)member.Grade))
            {
                Class newClass = new Class()
                {
                    ClassName = member.ClassName,
                    GradeId = member.Grade,
                    SchoolId = (int)member.School
                };
                classRepository.Add(newClass);
            }
            MemberRepository memberRepository = new MemberRepository();
            return memberRepository.Add(member);
        }

        public bool UpdateMember(Member member)
        {
            //检测school名字是否存在，如果存在，则将member.school存为school.Id
            //否则在表中插入新school数据，并将新数据的id赋值给school.Id
            SchoolRepository schoolRepository = new SchoolRepository();
            if (schoolRepository.SchoolNameExists(member.SchoolEntity.SchoolName))
            {
                member.School = schoolRepository.GetModelBySchoolName(member.SchoolEntity.SchoolName).SchoolId;
            }
            else
            {

                School school = member.SchoolEntity;
                schoolRepository.Add(school);
                member.School = schoolRepository.GetModelBySchoolName(school.SchoolName).SchoolId;
            }

            //检测Class名字是否存在，如果不存在,在class表中添加数据
            ClassRepository classRepository = new ClassRepository();
            if (!classRepository.Exists(member.ClassName, (int)member.School, (int)member.Grade))
            {
                Class newClass = new Class()
                {
                    ClassName = member.ClassName,
                    GradeId = member.Grade,
                    SchoolId = (int)member.School
                };
                classRepository.Add(newClass);
            }
            MemberRepository memberRepository = new MemberRepository();
            return memberRepository.Update(member);
        }

        public List<SXEdu2XHKD.Domain.Entities.Member> GetMemberListByRegisterDate(DateTime date)
        {
            return dal.GetMemberListByRegisterDate(date).ToList();
        }

        /// <summary>
        /// 获取全部用户列表
        /// </summary>
        /// <returns></returns>
        public List<SXEdu2XHKD.Domain.Entities.Member> GetAllMemberList()
        {
            return dal.GetAllMemberList().ToList();
        }
	}
}

