namespace BIIC_Contest.Dtos
{
    public class UserDto
    {
        private int userId;
        private string fullname;
        private string email;
        private string password;
        private string phone;
        private string createdAt;
        private string specialtyField; //Chuyên môn chỉ dành cho giám khảo
        private RoleDto role;

        public int UserId { get => userId; set => userId = value; }
        public string Fullname { get => fullname; set => fullname = value; }
        public string Email { get => email; set => email = value; }
        public string Password { get => password; set => password = value; }
        public string Phone { get => phone; set => phone = value; }
        public string CreatedAt { get => createdAt; set => createdAt = value; }
        public RoleDto Role { get => role; set => role = value; }
        public string SpecialtyField { get => specialtyField; set => specialtyField = value; }
    }
}