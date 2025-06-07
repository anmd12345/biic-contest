using BIIC_Contest.Databases;
using BIIC_Contest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BIIC_Contest.Repositorys
{
    public class RoleRepo
    {
        private BIICConnectionDbContext db = BIICConnectionDbContext.getInstance;

        public List<role> findAll()
        {
            return db.roles.ToList();
        }

        public role findById(int id)
        {
            return db.roles.FirstOrDefault(e=>e.role_id == id);
        }

        public role findByRoleName(string roleName)
        {
            return db.roles.FirstOrDefault(e => e.role_name.Equals(roleName));
        }
    }
}