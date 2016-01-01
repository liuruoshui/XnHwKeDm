using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SXEdu2XHKD.Domain.Entities;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
namespace SXEdu2XHKD.Domain.Transfer
{
    public class SXEduUserRepository
    {
       static public SXEduUserInfo Json2UserInfo(JObject jObject)
        {
            //{"SYS_HEAD":{
            //"RET":[{"RET_MSG":"操作成功","RET_CODE":"000000","SERVICE_CODE":"zteict.proxy.user.LoginStatus"}],"RET_STATUS":"S"},"BODY":\
            //{"CLASS_ARRAY":[
            //{"GRADE_NAME":"八年级",
            //"CLASS_NAME":"1402",
            //"GRADE_ID":"8",
            //"CLASS_ID":"28934"}],
            //"PHONE":"",
            //"GRADE_NAME":"八年级",
            //"USER_ID":"5033141",
            //"USER_NAME":"岳静珂",
            //"CLASS_NAME":"1402",
            //"SCHOOL_NAME":"太原市成成中学",
            //"SCHOOL_ID":"1401050003",
            //"GRADE_ID":"8",
            //"EMAIL":"",
            //"USER_TYPE":"00",
            //"NICKNAME":"yuejingke"}}
            SXEduUserInfo sxEduUserInfo = new SXEduUserInfo();

            //"CLASS_ARRAY":[
            SXEduClassInfo sxEduClassInfo = new SXEduClassInfo();

            //{"GRADE_NAME":"八年级",
            sxEduClassInfo.GradeName = jObject["BODY"]["CLASS_ARRAY"][0]["GRADE_NAME"].ToString();
            //"CLASS_NAME":"1402",
            sxEduClassInfo.ClassName = jObject["BODY"]["CLASS_ARRAY"][0]["CLASS_NAME"].ToString();
            //"GRADE_ID":"8",
            sxEduClassInfo.GradeId = jObject["BODY"]["CLASS_ARRAY"][0]["GRADE_ID"].ToString();
            //"CLASS_ID":"28934"}],
            sxEduClassInfo.ClassId = jObject["BODY"]["CLASS_ARRAY"][0]["CLASS_ID"].ToString();

            sxEduUserInfo.ClassInfo = sxEduClassInfo;

            //"PHONE"
            sxEduUserInfo.Phone = jObject["BODY"]["PHONE"].ToString();
            //"GRADE_NAME":"八年级",
            sxEduUserInfo.GradeName = jObject["BODY"]["GRADE_NAME"].ToString();
            //"USER_ID":"5033141",
            sxEduUserInfo.UserId = jObject["BODY"]["USER_ID"].ToString();
            //"USER_NAME":"岳静珂",
            sxEduUserInfo.UserName = jObject["BODY"]["USER_NAME"].ToString();
            //"CLASS_NAME":"1402",
            sxEduUserInfo.ClassName = jObject["BODY"]["CLASS_NAME"].ToString();
            //"SCHOOL_NAME":"太原市成成中学",
            sxEduUserInfo.SchoolName = jObject["BODY"]["SCHOOL_NAME"].ToString();
            //"SCHOOL_ID":"1401050003",
            sxEduUserInfo.SchoolId = jObject["BODY"]["SCHOOL_ID"].ToString();
            //"GRADE_ID":"8",
            sxEduUserInfo.GradeId = jObject["BODY"]["GRADE_ID"].ToString();
            //"EMAIL":"",
            sxEduUserInfo.Email = jObject["BODY"]["EMAIL"].ToString();
            //"USER_TYPE":"00",
            sxEduUserInfo.UserType = jObject["BODY"]["USER_TYPE"].ToString();
            //"NICKNAME":"yuejingke"
            sxEduUserInfo.NickName = jObject["BODY"]["NICKNAME"].ToString();

            return sxEduUserInfo;
        }
    }
}
