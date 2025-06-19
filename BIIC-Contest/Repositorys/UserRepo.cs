using BIIC_Contest.Constants;
using BIIC_Contest.Databases;
using BIIC_Contest.Models;
using System;
using System.Linq;

namespace BIIC_Contest.Repositorys
{
    public class UserRepo
    {
        private BIICConnectionDbContext db = BIICConnectionDbContext.getInstance;

        public bool checkExistByPhone(string phone)
        {
            return db.tbl_users.Any(u => u.phone.Equals(phone));
        }

        public bool checkExistByEmail(string email)
        {
            return db.tbl_users.Any(u => u.email.Equals(email));
        }

        public tbl_user findById(int id)
        {
            return db.tbl_users.FirstOrDefault(u => u.user_id == id);
        }

        public tbl_user findByPhone(string phone)
        {
            return db.tbl_users.FirstOrDefault(u => u.phone.Equals(phone));
        }

        public tbl_user findByEmail(string email)
        {
            return db.tbl_users.FirstOrDefault(u => u.email.Equals(email));
        }

        public tbl_user findByPhoneAndPassword(string phone, string password)
        {
            return db.tbl_users.FirstOrDefault(u => u.phone.Equals(phone) && u.password.Equals(password));
        }

        public tbl_user findByEmailAndPassword(string phone, string password)
        {
            return db.tbl_users.FirstOrDefault(u => u.email.Equals(phone) && u.password.Equals(password));
        }

        public tbl_user userSignup(string fullname, string email, string phone, string password, string createdAt)
        {
            try
            {
                tbl_user user = new tbl_user
                {
                    avatar = ResourceConstant.DEFAULT_AVATAR,
                    fullname = fullname,
                    email = email,
                    phone = phone,
                    password = password,
                    role_id = (short)RoleConstant.USER,
                    created_at = createdAt,
                    allow_view_activity_log = false
                };

                db.tbl_users.InsertOnSubmit(user);
                db.SubmitChanges();
                return user;
            }
            catch (Exception ex)
            {
                throw new Exception($"Không thể đăng ký. Error: ${ex.Message}");
            }
        }

        private tbl_user examinerSignup()
        {
            return null;
        }

        private tbl_user employeeSignup()
        {
            return null;
        }
    }
}