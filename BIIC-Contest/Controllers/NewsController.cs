using System.Web.Mvc;

namespace BIIC_Contest.Controllers
{
    public class NewsController : Controller
    {
        // GET: News

        [Route("tin-tuc")]
        public ActionResult News()
        {
            return View();
        }
    }
}