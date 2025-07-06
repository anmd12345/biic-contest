using BIIC_Contest.Databases;
using BIIC_Contest.Models;
using BIIC_Contest.Repositorys.I;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BIIC_Contest.Repositorys
{
    public class SubmissionRepository : ISubmissionRepository
    {
        private readonly BIICConnectionDbDataContext db;

        public SubmissionRepository()
        {
            db = new BIICConnectionDbDataContext(
                System.Configuration.ConfigurationManager.ConnectionStrings["biic_contest_dbConnectionString"].ConnectionString);
        }

        public IQueryable<tbl_submission> GetAll() => db.tbl_submissions;

        public tbl_submission GetById(int id) => db.tbl_submissions.FirstOrDefault(x => x.submission_id == id);

        public void Insert(tbl_submission submission) => db.tbl_submissions.InsertOnSubmit(submission);

        public void Update(tbl_submission submission) { /* Không cần viết gì nếu dùng SubmitChanges() */ }

        public void Delete(tbl_submission submission) => db.tbl_submissions.DeleteOnSubmit(submission);

        public void Save() => db.SubmitChanges();
    }
}