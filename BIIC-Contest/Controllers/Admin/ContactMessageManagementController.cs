using BIIC_Contest.Dtos;
using BIIC_Contest.Services;
using System.Collections.Generic;
using System.Web.Mvc;

namespace BIIC_Contest.Controllers.Admin
{
    [RoutePrefix("quan-ly-tin-nhan")]
    public class ContactMessageManagementController : Controller
    {
        private ContactMessageService contactMessageService = new ContactMessageService();


        [Route("danh-sach-tin-nhan")]
        public ActionResult ListContactMessage()
        {
            List<ContactMessageDto> contactMessages = contactMessageService.findAll();
            
            ViewBag.contactMessages = contactMessages;
           
            return View();
        }

        [Route("tin-nhan-chi-tiet")]
        public ActionResult ContactMessageDetail(/*int id*/)
        {
            return View();
        }
    }
}