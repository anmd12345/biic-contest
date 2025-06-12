using BIIC_Contest.Databases;
using BIIC_Contest.Models;
using System.Linq;

namespace BIIC_Contest.Repositorys
{
    public class UserRepo
    {
        private BIICConnectionDbContext db = BIICConnectionDbContext.getInstance;

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
    }
}