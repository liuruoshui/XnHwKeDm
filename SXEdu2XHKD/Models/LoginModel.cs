using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SXEdu2XHKD.WebUI.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "必须填写登录名")]
        [DisplayName("登录名")]
        [RegularExpression(@"^[a-zA-Z][a-zA-Z0-9]{3,15}$", ErrorMessage = "登录名必须以字母开头，可包含数字，长度为4-16个字符")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "必须填写密码")]
        [DisplayName("密码")]
        //[RegularExpression(@"^(?=.*[0-9])(?=.*[a-zA-Z])[a-z0-9A-Z]{6,15}$", ErrorMessage = "密码必须同时包含字母与数字，长度在6-15个字符")]
        public string PassWord { get; set; }

        public bool IsRemembered { get; set; }
    }
}