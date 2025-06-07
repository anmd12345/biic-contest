using BIIC_Contest.Databases;
using BIIC_Contest.Models;
using System.Linq;

namespace BIIC_Contest.Repositorys
{
    public class UserRepo
    {
        private BIICConnectionDbContext db = BIICConnectionDbContext.getInstance;

        public user findById(int id)
        {
            return db.users.FirstOrDefault(u => u.user_id == id);
        }

        public user findByPhone(string phone)
        {
            return db.users.FirstOrDefault(u => u.phone.Equals(phone));
        }

        public user findByEmail(string email)
        {
            return db.users.FirstOrDefault(u => u.email.Equals(email));
        }

        public user findByPhoneAndPassword(string phone, string password)
        {
            return db.users.FirstOrDefault(u => u.phone.Equals(phone) && u.password.Equals(password));
        }

        public user findByEmailAndPassword(string phone, string password)
        {
            return db.users.FirstOrDefault(u => u.phone.Equals(phone) && u.password.Equals(password));
        }
    }
}