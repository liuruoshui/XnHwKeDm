using SXEdu2XHKD.Domain.Concrete;
using SXEdu2XHKD.Domain.Entities;
using SXEdu2XHKD.WebUI.Helper;
using SXEdu2XHKD.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SXEdu2XHKD.WebUI.Controllers
{
    public class CourseController : Controller
    {
        //
        // GET: /Course/

        public ActionResult Index()
        {
            return View();
        }

        [MyAuthorizeAttribute]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult GetCourse(string CourseCode)
        {
            Pp22CourseViewRepository pp22CourseViewRepository = new Pp22CourseViewRepository();
            Pp22CourseView pp22CourseView = pp22CourseViewRepository.GetModelByCode(CourseCode);
            if (pp22CourseView != null)
            {
                Member member = Session["member"] as Member;
                LearningRecordRepository learningRecordRepository = new LearningRecordRepository();
                LearningRecord learningRecord = new LearningRecord()
                {
                    CourseCode = CourseCode,
                    MemberId = member.MemberId,
                    RecordTime = DateTime.Now,
                    SxEduUserName = member.SXEduUserName
                };
                learningRecordRepository.Add(learningRecord);
                return RedirectToAction("Learn", "Course", new { CourseCode = pp22CourseView.CourseCode, SwfId = pp22CourseView.Pp22CourseSwfs.FirstOrDefault().id });
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        [MyAuthorizeAttribute]
        public ActionResult Learn(string CourseCode, string SwfId)
        {
            Pp22CourseViewRepository pp22CourseViewRepository = new Pp22CourseViewRepository();
            Pp22CourseView pp22CourseView = pp22CourseViewRepository.GetModelByCode(CourseCode);
            Pp22CourseSwfRepository pp22CourseSwfRepository = new Pp22CourseSwfRepository();
            Pp22CourseSwf pp22CourseSwf = pp22CourseSwfRepository.GetModel(int.Parse(SwfId));

            CourseModel courseModel = EntityToViewModel.EntityToCourseModel(pp22CourseView, pp22CourseSwf);

            return View(courseModel);
        }
    }
}