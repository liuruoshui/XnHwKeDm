using SXEdu2XHKD.Domain.Concrete;
using SXEdu2XHKD.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SXEdu2XHKD.WebUI.Models
{
    public class EntityToViewModel
    {
        public static string[] _Grades = new string[]{
            "一年级",
            "二年级",
            "三年级",
            "四年级",
            "五年级",
            "六年级",
            "七年级",
            "八年级",
            "九年级",
            "高中一年级",
            "高中二年级",
            "高中三年级"
        };
        static EntityToViewModel()
        {
        }

        public static MemberInfoModel MemberToInfoModel(Member member)
        {
            MemberInfoModel infoModel = new MemberInfoModel()
            {
                UserName = member.UserName,
                SxEduUserName = member.SXEduUserName,
                ClassName = member.ClassName,
                Email = member.Email,
                School = member.SchoolEntity.SchoolName,
                Name = member.Name,
                QQ = member.QQ,
                RegisterTime = member.RegisterTime,
                Grade = GradeToString(member.Grade)
            };

            return infoModel;
        }

        public static MemberInfoResponseModel MemberToInfoResponseModel(Member member)
        {
            SchoolRepository schoolRepository = new SchoolRepository();
            member.SchoolEntity = schoolRepository.GetModel((int)member.School);

            MemberInfoResponseModel infoResponseModel = new MemberInfoResponseModel()
            {
                UserName = member.UserName,
                SxEduUserName = member.SXEduUserName,
                ClassName = member.ClassName,
                Email = member.Email,
                School = member.SchoolEntity.SchoolName,
                Name = member.Name,
                Birthday = member.BirthDay.ToString(),
                QQ = member.QQ,
                RegisterTime = member.RegisterTime.ToString(),
                Grade = GradeToString(member.Grade)
            };

            return infoResponseModel;
        }

        public static MemberInfoEditModel MemberToInfoEditModel(Member member)
        {
            MemberInfoEditModel memberInfoEditModel = new MemberInfoEditModel()
            {
                ClassName = member.ClassName,
                Email = member.Email,
                Name = member.Name,
                QQ = member.QQ
            };
            return memberInfoEditModel;
        }

        static string GradeToString(int Grade)
        {
            return _Grades[Grade];
        }

        public static void InfoEditModelSaveToEntity(MemberInfoEditModel memberInfoEditModel, Member member)
        {
            member.Name = memberInfoEditModel.Name;
            member.ClassName = memberInfoEditModel.ClassName;
            member.QQ = memberInfoEditModel.QQ;
            member.Email = memberInfoEditModel.Email;
            return;
        }

        public static LoginRecordResponseModel LoginRecordToLoginResponseModel(LoginRecord loginRecord)
        {
            LoginRecordResponseModel loginRecordResponseModel = new LoginRecordResponseModel()
            {
                LoginRecordId = loginRecord.LoginRecordId.ToString(),
                LogInTime = loginRecord.LogInTime.ToString(),
                LogOutTime = loginRecord.LogOutTime.ToString(),
                SXEduUserName = loginRecord.SXEduUserName
            };
            return loginRecordResponseModel;
        }

        public static ReSetPassWordModel MemberToReSetPassWordModel(Member member)
        {
            ReSetPassWordModel reSetPassWordModel = new ReSetPassWordModel()
            {
                Name = member.Name,
                UserName = member.UserName,
                PassWord = ""
            };
            return reSetPassWordModel;
        }

        public static CourseModel EntityToCourseModel(Pp22CourseView pp22CourseView,Pp22CourseSwf pp22CourseSwf){
            
            string UrlHttpLec = null;
            if(pp22CourseView.lx == "1"){
                UrlHttpLec = System.Configuration.ConfigurationManager.AppSettings["Urlbig"].ToString();
            }
            else{
                UrlHttpLec = System.Configuration.ConfigurationManager.AppSettings["Urlsmall"].ToString();
            }
            string UrlHttpSwf = System.Configuration.ConfigurationManager.AppSettings["Urlswf"].ToString();
            CourseModel courseModel = new CourseModel(){
                CourseCode = pp22CourseView.CourseCode,
                LecURL = UrlHttpLec + "/" + pp22CourseView.mulu.ToString() + "/" +  HttpUtility.UrlEncode(pp22CourseView.LecURL.ToString()),
                SwfURL = UrlHttpSwf + "/" + pp22CourseSwf.mulu.ToString() + "/" + pp22CourseSwf.swf.ToString(),
                SwfIds = new List<string>()
            };

            foreach(Pp22CourseSwf pp22CourseSwfIterator in pp22CourseView.Pp22CourseSwfs){
                courseModel.SwfIds.Add(pp22CourseSwfIterator.id.ToString());
            }
            return courseModel;
        }

        public static LearningRecordModel LearningRecordToLearningRecordModel(LearningRecord learningRecord)
        {
            LearningRecordModel learningRecordModel = new LearningRecordModel()
            {
                LearningRecordId = learningRecord.LearningRecordId,
                RecordTime = learningRecord.RecordTime.ToString(),
                SxEduUserName = learningRecord.SxEduUserName
            };
            return learningRecordModel;
        }
    }
}