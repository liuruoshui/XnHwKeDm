using SXEdu2XHKD.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace SXEdu2XHKD.WebUI.Helper
{
    public class MyAuthorizeAttribute : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            var isAuthorized = false;
            if (httpContext != null && httpContext.Session != null)
            {
                if (HttpContext.Current.Session["member"] != null)
                {
                    //TODO: 利用UserLoginStates和缓存确认唯一登陆
                    isAuthorized = true;
                }
            }
            else
            {
                //TODO:Cookie自动登录
            }

            return isAuthorized;
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            var routeValue = new RouteValueDictionary { 
                                { "Controller", "Login"}, 
                                { "Action", "Index"}
                                };

            filterContext.Result = new RedirectToRouteResult(routeValue);

            //base.HandleUnauthorizedRequest(filterContext);  
        }
    }
}