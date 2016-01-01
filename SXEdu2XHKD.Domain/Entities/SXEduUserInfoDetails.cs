using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SXEdu2XHKD.Domain.Entities
{
    public class SXEduUserInfoDetails
    {
        //{"SYS_HEAD":
        //{"RET":[{"RET_MSG":"操作成功","RET_CODE":"000000","SERVICE_CODE":"com.zte.space.homework.business.BusinessCenter4Homework.open__getUserInfo"}],"RET_STATUS":"S"},
        //"BODY":{


        //"CLASS_ARRAY":[{"GRADE_NAME":"八年级","CLASS_NAME":"1402","GRADE_ID":"8","CLASS_ID":"28934"}],
        SXEduClassInfo sxEduClassInfo { get; set; }

        //"CITY_ID":"1401",
        //"CITY_NAME":"太原市教研科研中心",
        string CityName {get;set;}

        //"CLASS_ID":"28934"
        //"CLASS_NAME":"1402",
        string ClassName { get; set; }

        //"id_card":"140106200012172549",
        string IdCard { get; set; }

        //"AREAL_ID":140106,
        //"AREAL_NAME":"迎泽区",
        string AreaName { get; set; }

        //"NICKNAME":"yuejingke",
        string NickName { get; set; }

        //"BIRTH_DATE":"",
        DateTime BirthDay { get; set; }

        //"USER_NAME":"岳静珂",
        string UserName { get; set; }

        //"GRADE_ID":"8",
        //"GRADE_NAME":"八年级",
        string GradeName { get; set; }


        //"SCHOOL_ID":"1401050003",
        //"SCHOOL_NAME":"太原市成成中学",
        string SchoolName { get; set; }

        //"COURSE_ID":"",
        string CourseId { get; set; }

        //"USER_ID":5033141,
        string UserId { get; set; }


        //"USER_TYPE":"00",
        string UserType { get; set; }


        //"PROVINCE_ID":"14",
        //"PROVINCE_NAME":"山西",
        string ProvinceName { get; set; }

        //"TELEPHONE":"",
        string TelePhone { get; set; }

        //"PART_ID":"1408",
        //"resultMessageKey":"SUCCESS",
        //"resultMessage":"SUCCESS",

        //"isSuccess":"true",
        //"VERIFY_AUTH":"0",
        //"TERM_ID":"01",

        //"LOGO":"",
        //"GROUP_TYPE":"S",
        //"VERIFICATE_EMAIL":"1",



        //"PASSWORD":"e10adc3949ba59abbe56e057f20f883e",
    }
}
