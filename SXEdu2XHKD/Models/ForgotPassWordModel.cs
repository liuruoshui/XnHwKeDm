using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SXEdu2XHKD.WebUI.Models
{
    public class ForgotPassWordModel
    {
        [DisplayName("山西教育资源公共服务平台用户名")]
        [Required(ErrorMessage="请填写用户名")]
        public string SXEduUserName { get; set; }
    }
}