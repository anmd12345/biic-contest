using BIIC_Contest.Dtos;
using BIIC_Contest.Entitys;

namespace BIIC_Contest.Services.I
{
    internal interface IUserService
    {
        // Define methods for user management
        UserDto login(string username, string password);

        BasicResponseEntity signup(string fullname, string email, string phone, string password, string specialtyField, string rePass, short role, string avatarUrl);

        BasicResponseEntity getUsers();
    }
}
