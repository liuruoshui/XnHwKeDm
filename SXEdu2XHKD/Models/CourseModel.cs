using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace SXEdu2XHKD.WebUI.Models
{
    public class CourseModel
    {
        [DisplayName("Lec地址")]
        public string LecURL { get; set; }
        [DisplayName("Url地址")]
        public string SwfURL { get; set; }
        [DisplayName("课程编码")]
        public string CourseCode { get; set; }
        [DisplayName("课程列表")]
        public List<string> SwfIds { get; set; }
    }
}