using BIIC_Contest.Services;
using System.Web.Mvc;
using BIIC_Contest.Constants;
using BIIC_Contest.Entitys;

namespace BIIC_Contest.Apis
{
    [RoutePrefix("apis/v1/contact-message")]
    public class ContactMessageApiController : Controller
    {
        private ContactMessageService contactMessageService = new ContactMessageService();

        [Route("save-contact-message")]
        [HttpPost]
        public JsonResult saveContactMessage(string fullname, string email, string phone, string message, string ip)
        {
            try
            {
                short responseCode = contactMessageService.createContactMessage(fullname, email, phone, message, ip);

                if (responseCode == (short)ResponseCodeConstant.SUCCESS)
                    return Json(new BasicResponseEntity(true, MessageConstant.ContactNotifications[responseCode]));
                return Json(new BasicResponseEntity(false, MessageConstant.ContactNotifications[responseCode]));
            }
            catch
            {
                return Json(new BasicResponseEntity(false, MessageConstant.ContactNotifications[(short)ResponseCodeConstant.UNKNOWN_ERROR]));
            }
        }

        [Route("list-contact-message")]
        [HttpGet]
        public JsonResult ListContactMessage()
        {
            return null;
        }

    }
}