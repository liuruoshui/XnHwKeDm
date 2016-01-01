using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace SXEdu2XHKD.WebUI.Models
{
    public class MemberInfoEditModel
    {
        [DisplayName("班级名")]
        public string ClassName { get; set; }

        [DisplayName("姓名")]
        public string Name { get; set; }

        [DisplayName("电子邮箱")]
        public string Email { get; set; }

        [DisplayName("QQ")]
        public string QQ { get; set; }
    }
}