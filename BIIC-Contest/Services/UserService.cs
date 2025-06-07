using BIIC_Contest.Dtos;
using BIIC_Contest.Services.I;

namespace BIIC_Contest.Services
{
    public class UserService : IUserService
    {
        //Hàm này sử dụng tên đăng nhập có thể là email hoặc số điện thoại và hash password để đăng nhập.
        //Vì vậy cần kiểm tra email và mật khẩu (hash trước khi truyền) hoặc số điện thoại và mật khẩu (hash trước khi truyền).
        //Chỉ cần 1 trong 2 trường hợp trên là đúng thì sẽ đăng nhập thành công.
        //Vì repo trả về là một đối tượng user nhưng ta chỉ cần kết quả là UserDto,
        //nên cần chuyển đổi từ đối tượng user -> UserDto.
        public UserDto login(string username, string password)
        {
            throw new System.NotImplementedException();
        }
    }
}