using System.Web.Mvc;

namespace BIIC_Contest.Controllers
{
    public class NewsController : BaseController
    {
        // GET: News

        [Route("tin-tuc")]
        public ActionResult News()
        {
            return View();
        }
    }
}