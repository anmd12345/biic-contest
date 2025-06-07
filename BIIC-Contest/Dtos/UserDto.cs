namespace BIIC_Contest.Dtos
{
    public class UserDto
    {
        private int userId;
        private string fullname;
        private string email;
        private string password;
        private string phone;
        private string specialtyField;
        private string createdAt;
        private RoleDto role;

        public UserDto() { }

        public UserDto(int userId, string fullname, string email, string password, string phone, string specialtyField, string createdAt, RoleDto role)
        {
            this.userId = userId;
            this.fullname = fullname;
            this.email = email;
            this.password = password;
            this.phone = phone;
            this.specialtyField = specialtyField;
            this.createdAt = createdAt;
            this.role = role;
        }

        public UserDto(string fullname, string email, string password, string phone, string specialtyField, string createdAt, RoleDto role)
        {
            this.fullname = fullname;
            this.email = email;
            this.password = password;
            this.phone = phone;
            this.specialtyField = specialtyField;
            this.createdAt = createdAt;
            this.role = role;
        }

        public int UserId { get => userId; set => userId = value; }
        public string Fullname { get => fullname; set => fullname = value; }
        public string Email { get => email; set => email = value; }
        public string Password { get => password; set => password = value; }
        public string Phone { get => phone; set => phone = value; }
        public string SpecialtyField { get => specialtyField; set => specialtyField = value; }
        public string CreatedAt { get => createdAt; set => createdAt = value; }
        public RoleDto Role { get => role; set => role = value; }
    }
}