using BIIC_Contest.Models;
using System.Collections.Generic;

namespace BIIC_Contest.Services.I
{
    internal interface IContactMessageService
    {
        // Khai báo các phương thức cần thiết để quản lý thông tin liên hệ
        short createContactMessage(string fullname, string email, string phone, string message, string ip);
        List<contact_message> findAll();
    }
}
