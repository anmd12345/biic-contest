using BIIC_Contest.Databases;
using BIIC_Contest.Helpers;
using BIIC_Contest.Models;

namespace BIIC_Contest.Repositorys
{
    // Các phương thức trong lớp này sẽ tương tác với cơ sở dữ liệu để quản lý thông tin liên hệ
    public class ContactMessageRepo
    {
        // Biến db được sử dụng để truy cập cơ sở dữ liệu
        private BIICConnectionDbContext db = BIICConnectionDbContext.getInstance;

        // Hàm thêm thông tin liên hệ
        public void createContactMessage(string fullname, string email, string phone, string message, string ip)
        {
            try
            {
                contact_message newContactMessage = createNewContactMessage(fullname, email, phone, message, ip);
                db.contact_messages.InsertOnSubmit(newContactMessage);
                db.SubmitChanges();
            }
            catch
            {
            }
        }

        private contact_message createNewContactMessage(string fullname, string email, string phone, string message, string ip)
        {
            return new contact_message
            {
                fullname = fullname,
                email = email,
                phone = phone,
                message = message,
                send_at = DateTimeHelper.getFormattedDateNow(),
                send_ip = ip
            };
        }
    }
}