using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BIIC_Contest.Models;

namespace BIIC_Contest.Repositorys.I
{
    public interface ISubmissionRepository
    {
        IQueryable<tbl_submission> GetAll();
        tbl_submission GetById(int id);
        void Insert(tbl_submission submission);
        void Update(tbl_submission submission);
        void Delete(tbl_submission submission);
        void Save();
    }
}