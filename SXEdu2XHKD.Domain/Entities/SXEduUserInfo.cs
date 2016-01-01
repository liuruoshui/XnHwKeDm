using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SXEdu2XHKD.Domain.Entities
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
    public class SXEduUserInfo
    {
        public SXEduClassInfo ClassInfo { get; set; }
        public string GradeName { get; set; }
        public string GradeId { get; set; }
        public string Phone { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string ClassName { get; set; }
        public string SchoolName { get; set; }
        public string SchoolId { get; set; }
        public string Email { get; set; }
        public string UserType { get; set; }
        public string NickName { get; set; }
    }
}