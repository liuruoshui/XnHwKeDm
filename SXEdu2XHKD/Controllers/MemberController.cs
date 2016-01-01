using SXEdu2XHKD.Domain.Concrete;
using SXEdu2XHKD.Domain.Entities;
using SXEdu2XHKD.WebUI.Helper;
using SXEdu2XHKD.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Caching;
using System.Web.Mvc;

namespace SXEdu2XHKD.WebUI.Controllers
{
    public class MemberController : Controller
    {
        //
        // GET: /User/
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost,ActionName("Register")]
        [ValidateAntiForgeryToken]
        public ActionResult RegisterMember(RegisterModel registerModel)
        {
            if (!ModelState.IsValid)
            {
                return View(registerModel);
            }

            MemberRepository memberRepository = new MemberRepository();

            //验证用户名是否已经存在
            Member member = memberRepository.GetModelByName(registerModel.UserName);
            if (member!=null && member.SXEduUserName != registerModel.SXEduUserName)
            {
                ModelState.AddModelError("NameExsists", "该用户名已存在,请更换登录名。");
                return View(registerModel);
            }
            else
            {
                member = memberRepository.GetModelBySXEduUserName(registerModel.SXEduUserName);
                member.UserName = registerModel.UserName;
                member.PassWord = registerModel.PassWord;

                memberRepository.Update(member);
            }

            return RedirectToAction("Index","Login");
        }

        [HttpGet]
        [MyAuthorizeAttribute]
        public ActionResult Info()
        {
            Member member = Session["member"] as Member;
            MemberInfoModel memberInfoModel = EntityToViewModel.MemberToInfoModel(member);
            return View(memberInfoModel);
        }

        [HttpGet]
        [MyAuthorizeAttribute]
        public ActionResult InfoEdit()
        {
            Member member = Session["member"] as Member;
            MemberInfoEditModel memberInfoEditModel = EntityToViewModel.MemberToInfoEditModel(member);
            return View(memberInfoEditModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult InfoEdit(MemberInfoEditModel memberInfoEditModel)
        {
            Member member = Session["member"] as Member;
            EntityToViewModel.InfoEditModelSaveToEntity(memberInfoEditModel, member);
            MemberRepository memberRepository = new MemberRepository();
            memberRepository.UpdateMember(member);
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult Exit()
        {
            //TODO: CLear Session
            Session.Abandon();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult ForgotPassWord()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ForgotPassWord(ForgotPassWordModel forgotPassWord)
        {

            if (!ModelState.IsValid)
            {
                return View();
            }

            MemberRepository memberRepository = new MemberRepository();

            //验证用户名是否存在
            Member member = memberRepository.GetModelBySXEduUserName(forgotPassWord.SXEduUserName);
            if (member == null)
            {
                ModelState.AddModelError("NameNotExsist", "该用户不存在或未激活，请检查用户名是否输入正确");
                return View();
            }
            else
            {
                member.UserStatus = (int)MemberStatus.ForgotPassWord;
                memberRepository.Update(member);
            }

            return Redirect("http://www.sxeduyun.com/portal/login.html");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ResetPassWord(ReSetPassWordModel reSetPassWordModel)
        {
            if (!ModelState.IsValid)
            {
                return View(reSetPassWordModel);
            }
            MemberRepository memberRepository = new MemberRepository();
            //验证用户名是否存在
            Member member = memberRepository.GetModelByName(reSetPassWordModel.UserName);
            if (member != null)
            {
                if (reSetPassWordModel.PassWord != null)
                {
                    member.PassWord = reSetPassWordModel.PassWord;
                    member.UserStatus = (int)MemberStatus.Normal;
                    memberRepository.Update(member);
                    return RedirectToAction("Index", "Login");
                }
            }
            return Redirect("http://www.sxeduyun.com/portal/login.html");
        }
	}
}