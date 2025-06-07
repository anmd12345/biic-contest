namespace BIIC_Contest.Services.I
{
    internal interface IContactMessageService
    {
        // Khai báo các phương thức cần thiết để quản lý thông tin liên hệ
        void createContactMessage(string fullname, string email, string phone, string message);
    }
}
