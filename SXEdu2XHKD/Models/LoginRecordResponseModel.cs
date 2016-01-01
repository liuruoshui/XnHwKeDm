using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SXEdu2XHKD.WebUI.Models
{
    public class LoginRecordResponseModel
    {
        public string LoginRecordId { get; set; }
        public string LogInTime { get; set; }
        public string LogOutTime { get; set; }
        public string SXEduUserName { get; set; }
    }
}