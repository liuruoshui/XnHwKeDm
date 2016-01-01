using SXEdu2XHKD.WebUI.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SXEdu2XHKD.WebUI.Controllers
{
    public class HomeController : Controller
    {
        // GET: /Home/
        [MyAuthorizeAttribute]
        public ActionResult Index()
        {
            return View(Session["member"]);
        }
	}
}