namespace BIIC_Contest.Dtos
{
    public class RoleDto
    {
        private short roleId;
        private string roleName;
        private string roleDescription;

        public short RoleId { get => roleId; set => roleId = value; }
        public string RoleName { get => roleName; set => roleName = value; }
        public string RoleDescription { get => roleDescription; set => roleDescription = value; }
    }
}