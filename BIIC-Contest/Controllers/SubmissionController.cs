using System.Web.Mvc;

namespace BIIC_Contest.Controllers
{
    public class SubmissionController : Controller
    {
        [Route("chi-tiet-bai-du-thi-v1")]
        public ActionResult SubmissionDetail()
        {
            return View();
        }
    }
}