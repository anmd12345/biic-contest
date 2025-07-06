using BIIC_Contest.Constants;
using BIIC_Contest.Dtos;
using BIIC_Contest.Entitys;
using BIIC_Contest.Helpers;
using BIIC_Contest.Models;
using BIIC_Contest.Repositorys;
using BIIC_Contest.Services.I;
using System.Collections.Generic;

namespace BIIC_Contest.Services
{
    public class UserService : IUserService, IBaseService
    {
        private UserRepo repo = new UserRepo();

        public BasicResponseEntity getUsers()
        {
            List<tbl_user> users = repo.findAll();

            return new BasicResponseEntity
            (
               true,
               "",
               toDtos(users)
            );
        }

        //Hàm này sử dụng tên đăng nhập có thể là email hoặc số điện thoại và hash password để đăng nhập.
        //Vì vậy cần kiểm tra email và mật khẩu (hash trước khi truyền) hoặc số điện thoại và mật khẩu (hash trước khi truyền).
        //Chỉ cần 1 trong 2 trường hợp trên là đúng thì sẽ đăng nhập thành công.
        public UserDto login(string username, string password)
        {
            tbl_user userResponse = repo.findByEmailAndPassword(username, HashHelper.hashPassword(password));

            if (userResponse == null)
            {
                userResponse = repo.findByPhoneAndPassword(username, HashHelper.hashPassword(password));
            }

            return toDto(userResponse);
        }

        public BasicResponseEntity signup(string fullname, string email, string phone, string password, string specialtyField, string rePass, short role, string avatarUrl)
        {
            switch (role)
            {
                case (short)RoleConstant.ADMIN:
                    break;
                case (short)RoleConstant.EMPLOYEE:
                    break;
                case (short)RoleConstant.EXAMINER:
                    {
                        if (ValidateDataHelper.isNullOrEmpty(fullname))
                        {
                            return new BasicResponseEntity
                            (
                                false,
                                MessageConstant.ErrorNotifications[5]
                            );
                        }

                        if (ValidateDataHelper.isNullOrEmpty(phone))
                        {
                            return new BasicResponseEntity
                            (
                                false,
                                MessageConstant.ErrorNotifications[4]
                            );
                        }

                        if (ValidateDataHelper.isNullOrEmpty(email))
                        {
                            return new BasicResponseEntity
                            (
                                false,
                                MessageConstant.ErrorNotifications[3]
                            );
                        }

                        if (ValidateDataHelper.isNullOrEmpty(password))
                        {
                            return new BasicResponseEntity
                            (
                                false,
                                MessageConstant.ErrorNotifications[6]
                            );
                        }

                        if (ValidateDataHelper.isNullOrEmpty(role.ToString()))
                        {
                            return new BasicResponseEntity
                            (
                                false,
                                MessageConstant.ErrorNotifications[14]
                            );
                        }

                        if (ValidateDataHelper.isNullOrEmpty(specialtyField))
                        {
                            return new BasicResponseEntity
                            (
                                false,
                                MessageConstant.ErrorNotifications[15]
                            );
                        }

                        if (!ValidateDataHelper.isValidPhoneNumber(phone))
                        {
                            return new BasicResponseEntity
                            (
                                false,
                                MessageConstant.ErrorNotifications[9]
                            );
                        }

                        if (!ValidateDataHelper.isValidEmail(email))
                        {
                            return new BasicResponseEntity
                            (
                                false,
                                MessageConstant.ErrorNotifications[10]
                            );
                        }

                        bool checkExistEmail = repo.checkExistByEmail(email);

                        if (checkExistEmail)
                        {
                            return new BasicResponseEntity
                            (
                                false,
                                MessageConstant.ErrorNotifications[0]
                            );
                        }

                        bool checkExistPhone = repo.checkExistByPhone(phone);

                        if (checkExistPhone)
                        {
                            return new BasicResponseEntity
                            (
                                false,
                                MessageConstant.ErrorNotifications[1]
                            );
                        }

                        string createdAt = DateTimeHelper.getFormattedDateNow();
                        string passwordHashed = HashHelper.hashPassword(password);

                        tbl_user user = repo.examinerSignup(fullname, email, phone, passwordHashed, specialtyField, createdAt, avatarUrl);

                        if (user != null)
                        {
                            UserDto data = toDto(user);
                            return new BasicResponseEntity
                            (
                                true,
                                MessageConstant.SuccessNotifications[0],
                                data
                            );
                        }

                        return new BasicResponseEntity
                        (
                            false,
                            MessageConstant.ErrorNotifications[2]
                        );
                    }
                case (short)RoleConstant.USER:
                    {
                        if (ValidateDataHelper.isNullOrEmpty(fullname))
                        {
                            return new BasicResponseEntity
                            (
                                false,
                                MessageConstant.ErrorNotifications[5]
                            );
                        }

                        if (ValidateDataHelper.isNullOrEmpty(email))
                        {
                            return new BasicResponseEntity
                            (
                                false,
                                MessageConstant.ErrorNotifications[3]
                            );
                        }

                        if (ValidateDataHelper.isNullOrEmpty(phone))
                        {
                            return new BasicResponseEntity
                            (
                                false,
                                MessageConstant.ErrorNotifications[4]
                            );
                        }

                        if (ValidateDataHelper.isNullOrEmpty(password))
                        {
                            return new BasicResponseEntity
                            (
                                false,
                                MessageConstant.ErrorNotifications[6]
                            );
                        }

                        if (ValidateDataHelper.isNullOrEmpty(rePass))
                        {
                            return new BasicResponseEntity
                            (
                                false,
                                MessageConstant.ErrorNotifications[7]
                            );
                        }

                        if(!ValidateDataHelper.isValidPhoneNumber(phone))
                        {
                            return new BasicResponseEntity
                            (
                                false,
                                MessageConstant.ErrorNotifications[9]
                            );
                        }

                        if (!ValidateDataHelper.isValidEmail(email))
                        {
                            return new BasicResponseEntity
                            (
                                false,
                                MessageConstant.ErrorNotifications[10]
                            );
                        }

                        if (!password.Equals(rePass)) {
                            return new BasicResponseEntity
                            (
                                false,
                                MessageConstant.ErrorNotifications[8]
                            );
                        }

                        bool checkExistEmail = repo.checkExistByEmail(email);

                        if (checkExistEmail)
                        {
                            return new BasicResponseEntity
                            (
                                false,
                                MessageConstant.ErrorNotifications[0]
                            );
                        }

                        bool checkExistPhone = repo.checkExistByPhone(phone);

                        if (checkExistPhone)
                        {
                            return new BasicResponseEntity
                            (
                                false,
                                MessageConstant.ErrorNotifications[1]
                            );
                        }

                        string createdAt = DateTimeHelper.getFormattedDateNow();
                        string passwordHashed = HashHelper.hashPassword(password);

                        tbl_user user = repo.userSignup(fullname, email, phone, passwordHashed, createdAt, avatarUrl);

                        if (user != null)
                        {
                            UserDto data = toDto(user);
                            return new BasicResponseEntity
                            (
                                true,
                                MessageConstant.SuccessNotifications[0],
                                data
                            );
                        }

                        return new BasicResponseEntity
                        (
                            false,
                            MessageConstant.ErrorNotifications[2]
                        );
                    }
            }
            
            return new BasicResponseEntity
            (
                false,
                MessageConstant.ErrorNotifications[2]
            );
        }


        public dynamic toDto(dynamic model)
        {
            tbl_user userResponse = model as tbl_user;

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
                SpecialtyField = userResponse.specialty_field,
                AvatarUrl = userResponse.avatar,
                Permission = new PermissionDto
                {

                }
            };
        }

        public dynamic toDtos(dynamic models)
        {
            List<tbl_user> users = models as List<tbl_user>;
            List<UserDto> dtos = new List<UserDto>();


            foreach (var user in users)
            {
                dtos.Add(toDto(user));
            }

            return dtos;
        }

        public dynamic toModel(dynamic dto)
        {
            throw new System.NotImplementedException();
        }

        public dynamic toModels(dynamic dtos)
        {
            throw new System.NotImplementedException();
        }
    }
}