using BIIC_Contest.Entitys;
using System;
using System.IO;
using System.Web;
using System.Web.Mvc;

namespace BIIC_Contest.Apis
{
    [RoutePrefix("apis/v1/upload")]
    public class UploadApisController : Controller
    {
        [HttpPost]
        [Route("upload-logo")]
        public JsonResult UploadLogo(HttpPostedFileBase file)
        {
            if (file == null || file.ContentLength == 0)
                return Json(new BasicResponseEntity { Success = false, Message = "Không có file nào được tải lên!" , Data = ""});

            var uploadsFolder = Server.MapPath("~/assets/img/system");
            if (!Directory.Exists(uploadsFolder))
                Directory.CreateDirectory(uploadsFolder);

            var fileName = Guid.NewGuid() + Path.GetExtension(file.FileName);
            var filePath = Path.Combine(uploadsFolder, fileName);

            file.SaveAs(filePath);

            return Json(new BasicResponseEntity { Success = true, Message = "Upload thành công!", Data = fileName });
        }
    }
}