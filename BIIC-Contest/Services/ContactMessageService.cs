using BIIC_Contest.Helpers;
using BIIC_Contest.Models;
using BIIC_Contest.Repositorys;
using BIIC_Contest.Services.I;
using System.Collections.Generic;

namespace BIIC_Contest.Services
{
    public class ContactMessageService : IContactMessageService
    {
        // Lớp này sẽ sử lý logic và thực hiện các thao tác liên quan đến thông tin liên hệ
        private ContactMessageRepo repo = new ContactMessageRepo();

        public short createContactMessage(string fullname, string email, string phone, string message, string ip)
        {
            try
            {
                if (ValidateDataHelper.isNullOrEmpty(fullname)) return 1;
                if (ValidateDataHelper.isNullOrEmpty(phone)) return 2;
                if (!ValidateDataHelper.isValidPhoneNumber(phone)) return 3;
                //if (!ValidateDataHelper.isNullOrEmpty(email)) return 4;
                if (!ValidateDataHelper.isValidEmail(email)) return 5;
                if (ValidateDataHelper.isNullOrEmpty(message)) return 6;

                string sendAt = DateTimeHelper.getFormattedDateNow();

                repo.createContactMessage(fullname, email, phone, message, ip, sendAt);
                return 0;
            }
            catch
            {
                return 7;
            }
        }

        public List<contact_message> findAll()
        {
            return repo.findAll();
        }
    }
}