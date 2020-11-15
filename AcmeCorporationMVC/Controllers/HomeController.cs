using AcmeCorporationMVC.Models;
using PagedList;
using System.Web.Mvc;
using static AcmeCorporationClassLibrary.BusinessLogic.SubmissionProcessor;

namespace AcmeCorporationMVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SubmitSerial()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult SubmitSerial(SubmissionModel submissionModel)
        {
            if (ModelState.IsValid)
            {
                string creationMessage = CreateSubmission(submissionModel.FirstName,
                                                          submissionModel.LastName,
                                                          submissionModel.EmailAddress,
                                                          submissionModel.SerialNumber);
                return Json(creationMessage);
            }
            return Json("Invalid form input.");
        }

        public ActionResult ViewSubmissions(int? page)
        {
            var submissionData = LoadSubmissions();
            var pageNumber = page ?? 1;
            var onePageOfProducts = submissionData.ToPagedList(pageNumber, 5);

            ViewBag.OnePageOfProducts = onePageOfProducts;
            return View();
        }
    }
}