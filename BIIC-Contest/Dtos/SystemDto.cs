namespace BIIC_Contest.Dtos
{
    public class SystemDto
    {
        private string logoUrl;
        private string shortTitle;
        private string phone;
        private string email;
        private string address;
        private bool isShowNotification;
        private bool isAllow;

        public string LogoUrl { get => logoUrl; set => logoUrl = value; }
        public string ShortTitle { get => shortTitle; set => shortTitle = value; }
        public string Phone { get => phone; set => phone = value; }
        public string Email { get => email; set => email = value; }
        public string Address { get => address; set => address = value; }
        public bool IsShowNotification { get => isShowNotification; set => isShowNotification = value; }
        public bool IsAllow { get => isAllow; set => isAllow = value; }
    }
}