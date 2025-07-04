using BIIC_Contest.Dtos;
using BIIC_Contest.Entitys;
using BIIC_Contest.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace BIIC_Contest.Apis
{
    [RoutePrefix("apis/v1/system")]
    public class SystemApisController : Controller
    {
        private SystemService systemService = new SystemService();

        [Route("update")]
        [HttpPost]
        public JsonResult UpdateSystemInfo(string shortTitle, string logoUrl, string phone, string email, string address, bool allowNotification, bool allowAccess)
        {
            BasicResponseEntity response = systemService.update(shortTitle, logoUrl, phone, email, address, allowNotification, allowAccess);

            return Json(response);
        }


        [Route("delete-logo")]
        [HttpPost]
        public JsonResult DeleteLogo()
        {
            BasicResponseEntity response = systemService.deleteLogo();

            return Json(response);
        }
    }
}