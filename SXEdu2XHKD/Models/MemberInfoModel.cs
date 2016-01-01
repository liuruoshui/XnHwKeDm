using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace SXEdu2XHKD.WebUI.Models
{
    public class MemberInfoModel
    {
        [DisplayName("山西教育平台用户名")]
        public string SxEduUserName { get; set; }

        [DisplayName("学校")]
        public string School { get; set; }

        [DisplayName("年级")]
        public string Grade { get; set; }

        [DisplayName("班级名")]
        public string ClassName { get; set; }

        [DisplayName("用户名")]
        public string UserName { get; set; }

        [DisplayName("姓名")]
        public string Name { get; set; }

        [DisplayName("电子邮箱")]
        public string Email { get; set; }

        [DisplayName("注册时间")]
        public DateTime RegisterTime { get; set; }

        [DisplayName("QQ")]
        public string QQ { get; set; }
    }
}