using BIIC_Contest.Services;
using System.Web.Mvc;
using BIIC_Contest.Constants;
using BIIC_Contest.Helpers;

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
                    return Json(new { success = true, message = MessageConstant.ContactNotifications[responseCode] });
                return Json(new { success = false, message = MessageConstant.ContactNotifications[responseCode] });
            }
            catch
            {
                return Json(new { success = false, message = MessageConstant.ContactNotifications[(short)ResponseCodeConstant.UNKNOWN_ERROR] });
            }
        }

    }
}