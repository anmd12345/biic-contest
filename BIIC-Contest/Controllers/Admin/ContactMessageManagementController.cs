using BIIC_Contest.Constants;
using BIIC_Contest.Dtos;
using BIIC_Contest.Services;
using System.Collections.Generic;
using System.Web.Mvc;

namespace BIIC_Contest.Controllers.Admin
{
    [RoutePrefix("tin-nhan")]
    public class ContactMessageManagementController : BaseAdminController
    {
        private ContactMessageService contactMessageService = new ContactMessageService();


        [Route("danh-sach-tin-nhan")]
        public ActionResult ListContactMessage()
        {
            List<ContactMessageDto> contactMessages = contactMessageService.findAll();
            
            ViewBag.contactMessages = contactMessages;
           
            return View();
        }

        [Route("chi-tiet-tin-nhan/{id}")]
        public ActionResult ContactMessageDetail(int id)
        {
            ContactMessageDto contactMessage = contactMessageService.getContactMessageById(id);

            if (id <= 0 || contactMessage == null)
            {
                return Redirect(RouteConstant._404);
            }

            List<ContactMessageDto> contactMessages = contactMessageService.findAll();

            ViewBag.contactMessages = contactMessages;
            ViewBag.contactMessage = contactMessage;

            return View();
        }
    }
}