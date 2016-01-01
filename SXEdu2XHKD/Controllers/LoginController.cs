using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using SXEdu2XHKD.Domain.Entities;
using System.Net.Http;
using SXEdu2XHKD.Domain.Concrete;
using SXEdu2XHKD.Domain.Transfer;
using SXEdu2XHKD.WebUI.Models;
using SXEdu2XHKD.Domain.Common;
using System.Collections;

namespace SXEdu2XHKD.WebUI.Controllers
{
    public class LoginController : Controller
    {

        // GET: /SXEduLogin/
        public ActionResult SXEduLogin()
        {
            //strToken为传入Token参数，
            string strToken = Request.QueryString["Tocken"];
            if (strToken == null)
            {
                //Session[""member"]为存储省平台用户信息的SXEduUserInfo对象。
                if (Session["member"] != null)
                {
                    return RedirectToAction("Index", "Home");
                }

                return Redirect("http://www.sxeduyun.com/portal/login.html");
            }

            var tokenJson = new
            {
                SERVICE_CODE = "zteict.proxy.user.LoginStatus",
                CONSUMER_ID = strToken
            };

            HttpClient client = new HttpClient();
            //拼接url，使用token获取验证信息
            StringBuilder sb = new StringBuilder();
            sb.Append("http://www.sxeduyun.com/serviceProxy/servlet/?json=");
            sb.Append(JsonConvert.SerializeObject(tokenJson));
            string uri = sb.ToString();

            string ResponsedUserInfo = client.GetStringAsync(uri).Result;

            //ViewBag.ResponsedUserInfo = ResponsedUserInfo;

            JObject jObject = JObject.Parse(ResponsedUserInfo);
            try
            {
                //验证验证信息
                string result = jObject["SYS_HEAD"]["RET"][0]["RET_MSG"].ToString();
                
                if (result.Trim().Equals("操作成功"))
                {
                    
                    string str = jObject["SYS_HEAD"].ToString();
                    SXEduUserInfo sxEduUserInfo = SXEduUserRepository.Json2UserInfo(jObject);

                    MemberRepository memberRepository = new MemberRepository();

                    Member member = memberRepository.GetModelBySXEduUserName(sxEduUserInfo.NickName);

                    if (member != null)
                    {
                        if (!String.IsNullOrEmpty(member.PassWord))
                        {
                            switch(member.UserStatus)
                            {
                                case (int)MemberStatus.ForgotPassWord:
                                    return View("ReSetPassWord", EntityToViewModel.MemberToReSetPassWordModel(member));
                                case (int)MemberStatus.Normal:
                                    SetSession(member);
                                    return RedirectToAction("Index", "Home");
                                case (int)MemberStatus.Banned:
                                    return RedirectToAction("Index", "Home");
                            }
                        }
                        else
                        {
                            RegisterModel registerModel = new RegisterModel()
                            {
                                Name = member.Name,
                                UserName = member.UserName,
                                SXEduUserName = member.SXEduUserName
                            };
                            return View("~/Views/Member/Register.cshtml",registerModel);
                        }
                    }
                    else
                    {
                        member = memberRepository.TransferMemberFromSXEduUserInfo(sxEduUserInfo);

                        var DetailJson = new
                        {
                            SERVICE_CODE = "com.zte.space.homework.business.BusinessCenter4Homework.open-getUserInfo",
                            CONSUMER_ID = strToken
                        };

                        //拼接url，使用token获取详细
                        sb = new StringBuilder();
                        sb.Append("http://www.sxeduyun.com/serviceProxy/servlet/?json=");
                        sb.Append(JsonConvert.SerializeObject(tokenJson));
                        uri = sb.ToString();


                        string ResponseUserInfo = client.GetStringAsync(uri).Result;
                        jObject = JObject.Parse(ResponsedUserInfo);

                        member.SxEduUserInfo = jObject["BODY"].ToString();

                        member.RegisterTime = DateTime.Now;
                        memberRepository.AddNewMember(member);
                        RegisterModel registerModel = new RegisterModel()
                        {
                            SXEduUserName = member.SXEduUserName,
                            UserName = member.UserName,
                            Name = member.Name
                        };
                        return View("~/Views/Member/Register.cshtml",registerModel);
                    }

                }
                return Redirect("http://www.sxeduyun.com/portal/login.html");
            }
            catch
            {
                return Redirect("http://www.sxeduyun.com/portal/login.html");
            }
        }

        [HttpGet]
        public ActionResult Index()
        {
            Session["guid"] = Guid.NewGuid().ToString();
            ViewBag.Guid = Session["guid"];
            string guid = Session["guid"] as string;
            LoginModel loginModel = new LoginModel();
            return View(loginModel);
        }

        [HttpPost, ActionName("Index")]
        [ValidateAntiForgeryToken]
        public ActionResult Index(LoginModel loginModel)
        {
            //TODO: examine PassWord And UserName

            MemberRepository memberRepository = new MemberRepository();
            Member member = memberRepository.GetModelByName(loginModel.UserName);
            if (member != null)
            {
                string guid = Session["guid"] as string;
                string md5PasswordWithGuid = PassWordProcessing.GetMd5(member.PassWord + Session["guid"]);
                if (loginModel.PassWord== md5PasswordWithGuid && member.UserStatus != (int)MemberStatus.Banned)
                {
                    if (member.UserStatus != (int)MemberStatus.Normal)
                    {
                        member.UserStatus = (int)MemberStatus.Normal;
                        memberRepository.Update(member);
                    }
                    SetSession(member);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    Session["guid"] = Guid.NewGuid().ToString();
                    ViewBag.Guid = Session["guid"];
                    ModelState.AddModelError("InfoWrong", "密码错误，请核实后重新登录。");
                    return View(loginModel);
                }
            }
            else
            {
                Session["guid"] = Guid.NewGuid().ToString();
                ViewBag.Guid = Session["guid"];
                ModelState.AddModelError("InfoWrong", "用户不存在或未激活，请核实后重新登录。");
                return View(loginModel);
            }
        }

        private void SetSession(Member member){
            SchoolRepository schoolRepository = new SchoolRepository();
            member.SchoolEntity = schoolRepository.GetModel((int)member.School);
            Session["member"] = member;
            Session["logInTime"] = DateTime.Now;
        }
    }
}