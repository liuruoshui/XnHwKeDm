using SXEdu2XHKD.Domain.Concrete;
using SXEdu2XHKD.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;

namespace SXEdu2XHKD.WebUI
{
    // 注意: 有关启用 IIS6 或 IIS7 经典模式的说明，
    // 请访问 http://go.microsoft.com/?LinkId=9394801
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }

        void Session_End(object sender, EventArgs e)
        {
            Member member = Session["member"] as Member;
            LoginRecordRepository loginRecordRepository = new LoginRecordRepository();
            LoginRecord loginRecord = new LoginRecord()
            {
                LogInTime = (DateTime)Session["logInTime"],
                LogOutTime = DateTime.Now,
                MemberId = member.MemberId,
                SXEduUserName = member.SXEduUserName
            };
            loginRecordRepository.Add(loginRecord);
        }
    }
}