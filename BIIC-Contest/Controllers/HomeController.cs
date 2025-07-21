using BIIC_Contest.Constants;
using BIIC_Contest.Services;
using System.Web.Mvc;

namespace BIIC_Contest.Controllers
{
    public class HomeController : BaseController
    {

        private NewsService newsService = new NewsService();


        public ActionResult Index()
        {
            return RedirectToAction("Home");
        }

        [Route("trang-chu")]
        public ActionResult Home()
        {
            var contest = newsService.getActiveConstest();

            if (contest.Success)
            {
                ViewBag.contest = contest.Data;
            }

            return View();
        }

        [Route("lien-he")]
        public ActionResult Contact()
        {
            return View();
        }
    }
}