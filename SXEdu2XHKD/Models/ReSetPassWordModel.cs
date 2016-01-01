using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SXEdu2XHKD.WebUI.Models
{
    public class ReSetPassWordModel
    {
        public string UserName { get; set; }

        [Required(ErrorMessage = "必须填写密码")]
        [DisplayName("密码")]
        public string PassWord { get; set; }

        public string Name { get; set; }
    }
}