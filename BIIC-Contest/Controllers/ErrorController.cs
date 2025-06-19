using System.Web.Mvc;

namespace BIIC_Contest.Controllers
{
    public class ErrorController : BaseController
    {
        [Route("404")]
        public ActionResult NotFound()
        {
            return View();
        }

        [Route("500")]
        public ActionResult ServerInternal()
        {
            return View();
        }
    }
}