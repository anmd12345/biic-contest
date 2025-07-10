using System.Web.Mvc;

namespace BIIC_Contest.Controllers
{
    // Thay đổi "Controller" thành "BaseExaminerController"
    public class ExaminerController : BaseExaminerController
    {
        // GET: Examiner
        public ActionResult Index()
        {
            return View();
        }
    }
}