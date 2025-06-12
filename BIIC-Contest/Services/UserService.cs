using BIIC_Contest.Dtos;
using BIIC_Contest.Helpers;
using BIIC_Contest.Models;
using BIIC_Contest.Repositorys;
using BIIC_Contest.Services.I;

namespace BIIC_Contest.Services
{
    public class UserService : IUserService
    {
        private UserRepo repo = new UserRepo();

        //Hàm này sử dụng tên đăng nhập có thể là email hoặc số điện thoại và hash password để đăng nhập.
        //Vì vậy cần kiểm tra email và mật khẩu (hash trước khi truyền) hoặc số điện thoại và mật khẩu (hash trước khi truyền).
        //Chỉ cần 1 trong 2 trường hợp trên là đúng thì sẽ đăng nhập thành công.
        //Vì repo trả về là một đối tượng user nhưng ta chỉ cần kết quả là UserDto,
        //nên cần chuyển đổi từ đối tượng user -> UserDto.
        public UserDto login(string username, string password)
        {
            tbl_user userResponse = repo.findByEmailAndPassword(username, HashHelper.hashPassword(password));

            if (userResponse == null)
            {
                userResponse = repo.findByPhoneAndPassword(username, HashHelper.hashPassword(password));
            }

            return convertToUserDto(userResponse);
        }


        private UserDto convertToUserDto(tbl_user userResponse)
        {
            if (userResponse == null)
                return null;

            return new UserDto
            {
                UserId = userResponse.user_id,
                Fullname = userResponse.fullname,
                Email = userResponse.email,
                Phone = userResponse.phone,
                Password = userResponse.password,
                CreatedAt = userResponse.created_at,
                Role = new RoleDto
                {
                    RoleId = userResponse.tbl_role.role_id,
                    RoleName = userResponse.tbl_role.role_name,
                    RoleDescription = userResponse.tbl_role.description
                },
                SpecialtyField = userResponse.specialty_field
            };
        }
    }
}