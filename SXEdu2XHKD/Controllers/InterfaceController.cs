using Newtonsoft.Json;
using SXEdu2XHKD.Domain.Concrete;
using SXEdu2XHKD.Domain.Entities;
using SXEdu2XHKD.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SXEdu2XHKD.WebUI.Controllers
{
    public class InterfaceController : Controller
    {
        //
        // GET: /Interface/
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 获取从省平台获取的用户信息
        /// </summary>
        /// <returns></returns>
        public ActionResult GetSxEduUserInfo()
        {
            InterfaceResponseModel interfaceResponseModel = new InterfaceResponseModel();
            string strSxEduUserName = Request.QueryString["SxEduUserName"];

            if (!String.IsNullOrEmpty(strSxEduUserName))
            {
                MemberRepository memberRepository = new MemberRepository();
                Member member = memberRepository.GetModelBySXEduUserName(strSxEduUserName);
                if (member != null)
                {
                    interfaceResponseModel.Successful = true;
                    dynamic SxEduUserInfo = JsonConvert.DeserializeObject(member.SxEduUserInfo);
                    interfaceResponseModel.Response = SxEduUserInfo;
                }
            }
            return Content(JsonConvert.SerializeObject(interfaceResponseModel), "text/json");
        }

        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <returns></returns>
        public ActionResult GetUserInfo()
        {
            InterfaceResponseModel interfaceResponseModel = new InterfaceResponseModel();

            string strSxEduUserName = Request.QueryString["SxEduUserName"];
            if (!String.IsNullOrEmpty(strSxEduUserName))
            {
                MemberRepository memberRepository = new MemberRepository();
                Member member = memberRepository.GetModelBySXEduUserName(strSxEduUserName);
                if (member != null)
                {
                    interfaceResponseModel.Successful = true;
                    interfaceResponseModel.Response = EntityToViewModel.MemberToInfoResponseModel(member);
                }
            }
            return Json(interfaceResponseModel, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 根据登录日期获取登录记录
        /// </summary>
        /// <returns></returns>
        public ActionResult GetLoginListByDate()
        {
            InterfaceResponseModel interfaceResponseModel = new InterfaceResponseModel();
            string strDate = Request.QueryString["Date"];
            //strDate += " 00:00:00";
            DateTime dateTime = new DateTime();
            if (DateTime.TryParse(strDate, out dateTime))
            {
                LoginRecordRepository loginRecordRepository = new LoginRecordRepository();
                List<LoginRecord> loginRecordList = loginRecordRepository.GetLoginRecordByDate(dateTime);
                if (loginRecordList != null)
                {
                    List<LoginRecordResponseModel> loginRecordResponseModelList = new List<LoginRecordResponseModel>();
                    foreach (LoginRecord loginRecord in loginRecordList)
                    {
                        loginRecordResponseModelList.Add(EntityToViewModel.LoginRecordToLoginResponseModel(loginRecord));
                    }
                    interfaceResponseModel.Successful = true;
                    interfaceResponseModel.Response = loginRecordResponseModelList;
                };
            }
            return Json(interfaceResponseModel, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 根据注册日期获取用户信息
        /// </summary>
        /// <returns></returns>
        public ActionResult GetMemberInfoByRegisterDate()
        {
            InterfaceResponseModel interfaceResponseModel = new InterfaceResponseModel();
            string strDate = Request.QueryString["Date"];
            //strDate += " 00:00:00";
            DateTime dateTime = new DateTime();
            if (DateTime.TryParse(strDate, out dateTime))
            {
                MemberRepository memberRepository = new MemberRepository();
                List<Member> memberList = memberRepository.GetMemberListByRegisterDate(dateTime);
                if (memberList != null)
                {
                    List<MemberInfoResponseModel> memberInfoResponseModelList = new List<MemberInfoResponseModel>();
                    foreach (Member member in memberList)
                    {
                        memberInfoResponseModelList.Add(EntityToViewModel.MemberToInfoResponseModel(member));
                    }
                    interfaceResponseModel.Successful = true;
                    interfaceResponseModel.Response = memberInfoResponseModelList;
                };
            }
            return Json(interfaceResponseModel, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 获取所有注册用户列表
        /// </summary>
        /// <returns></returns>
        public ActionResult GetAllMemberList()
        {
            InterfaceResponseModel interfaceResponseModel = new InterfaceResponseModel();
            MemberRepository memberRepository = new MemberRepository();
            List<Member> memberList = memberRepository.GetAllMemberList();
            if (memberList != null)
            {
                List<MemberInfoResponseModel> memberInfoResponseModelList = new List<MemberInfoResponseModel>();
                foreach (Member member in memberList)
                {
                    memberInfoResponseModelList.Add(EntityToViewModel.MemberToInfoResponseModel(member));
                }
                interfaceResponseModel.Successful = true;
                interfaceResponseModel.Response = memberInfoResponseModelList;
            };
            return Json(interfaceResponseModel, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetLearningRecordByDate()
        {
            InterfaceResponseModel interfaceResponseModel = new InterfaceResponseModel();
            string strDate = Request.QueryString["Date"];
            //strDate += " 00:00:00";
            DateTime dateTime = new DateTime();
            if (DateTime.TryParse(strDate, out dateTime))
            {
                LearningRecordRepository learningRecordRepository = new LearningRecordRepository();
                List<LearningRecord> learningRecordList = learningRecordRepository.GetLearningRecordByDate(dateTime);
                if (learningRecordList != null)
                {
                    List<LearningRecordModel> learningRecordModelList = new List<LearningRecordModel>();
                    foreach (LearningRecord learningRecord in learningRecordList)
                    {
                        learningRecordModelList.Add(EntityToViewModel.LearningRecordToLearningRecordModel(learningRecord));
                    }
                    interfaceResponseModel.Successful = true;
                    interfaceResponseModel.Response = learningRecordModelList;
                };
            }
            return Json(interfaceResponseModel, JsonRequestBehavior.AllowGet);
        }
    }
}