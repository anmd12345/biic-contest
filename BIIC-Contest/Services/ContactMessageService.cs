using BIIC_Contest.Repositorys;
using BIIC_Contest.Services.I;
using System;

namespace BIIC_Contest.Services
{
    public class ContactMessageService : IContactMessageService
    {
        // Lớp này sẽ sử lý logic và thực hiện các thao tác liên quan đến thông tin liên hệ
        private ContactMessageRepo repo = new ContactMessageRepo();

        public void createContactMessage(string fullname, string email, string phone, string message)
        {
            throw new NotImplementedException();
        }
    }
}