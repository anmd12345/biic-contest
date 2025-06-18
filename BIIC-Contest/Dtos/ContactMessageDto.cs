namespace BIIC_Contest.Dtos
{
    public class ContactMessageDto
    {
        private int contactMessageId;
        private string fullname;
        private string email;
        private string phone;
        private string message;
        private string sendAt;
        private string sendIp;
        private bool isSeen;

        public int ContactMessageId { get => contactMessageId; set => contactMessageId = value; }
        public string Fullname { get => fullname; set => fullname = value; }
        public string Email { get => email; set => email = value; }
        public string Phone { get => phone; set => phone = value; }
        public string Message { get => message; set => message = value; }
        public string SendAt { get => sendAt; set => sendAt = value; }
        public string SendIp { get => sendIp; set => sendIp = value; }
        public bool IsSeen { get => isSeen; set => isSeen = value; }
    }
}