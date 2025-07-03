using BIIC_Contest.Databases;
using BIIC_Contest.Models;
using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Web;

namespace BIIC_Contest.Repositorys
{
    public class CategoryRepository
    {
        private BIICConnectionDbContext db = BIICConnectionDbContext.getInstance;

        public tbl_category findByCategoryName(string categoryName)
        {
            return db.tbl_categories.FirstOrDefault(e => e.category_name.Equals(categoryName));
        }

        public List<tbl_category> findAll()
        {
            return db.tbl_categories.ToList();
        }

        public tbl_category findById(int id)
        {
            return db.tbl_categories.FirstOrDefault(e => e.category_id == id);
        }

        public bool isExist(string categoryName)
        {
            return db.tbl_categories.Any(e => e.category_name.Equals(categoryName));
        }

        public bool insert(string categoryName, string description)
        {
            try
            {
                tbl_category category = createCategory(categoryName, description);

                db.tbl_categories.InsertOnSubmit(category);
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool update(short id, string newCategoryName, string newDescription)
        {
            tbl_category category = findById(id);
            if (category != null)
            {
                category.description = newDescription;
                category.category_name = newCategoryName;
                db.SubmitChanges();
                return true;
            }

            return false;
        }

        public bool delete(short id)
        {
            try
            {
                using (var db = BIICConnectionDbContext.refreshConnection)
                {
                    tbl_category category = findById(id);
                    if (category != null)
                    {
                        db.tbl_categories.DeleteOnSubmit(category);
                        db.SubmitChanges();
                        return true;
                    }
                }
                return false;
            }
            catch
            {
                return false;
            }
        }

        private tbl_category createCategory(string categoryName, string description)
        {
            return new tbl_category
            {
                category_name = categoryName,
                description = description
            };
        }
    }
}