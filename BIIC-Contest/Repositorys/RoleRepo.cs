using BIIC_Contest.Databases;
using BIIC_Contest.Models;
using System.Collections.Generic;
using System.Linq;

namespace BIIC_Contest.Repositorys
{
    public class RoleRepo
    {
        private BIICConnectionDbContext db = BIICConnectionDbContext.getInstance;

        public List<tbl_role> findAll()
        {
            return db.tbl_roles.ToList();
        }

        public tbl_role findById(int id)
        {
            return db.tbl_roles.FirstOrDefault(e=>e.role_id == id);
        }

        public tbl_role findByRoleName(string roleName)
        {
            return db.tbl_roles.FirstOrDefault(e => e.role_name.Equals(roleName));
        }
    }
}