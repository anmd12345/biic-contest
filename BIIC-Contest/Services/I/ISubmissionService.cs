using BIIC_Contest.Dtos;
using BIIC_Contest.Models;
using BIIC_Contest.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BIIC_Contest.Services.I
{
    public interface ISubmissionService
    {
        IEnumerable<tbl_submission> GetPaged(string field, string status, int page, int pageSize, out int totalRecords);
        tbl_submission GetById(int id);
        void UpdateStatus(int id, string status, out string message);
        void UploadFile(int id, HttpPostedFileBase file, string uploadPath, out string message);
        void Create(tbl_submission model, HttpPostedFileBase file, string uploadPath, out string message);
        void Delete(int id, string uploadPath, out string message);
        bool IsEmailExists(string email);

        void SaveGradingResult(int submissionId, int examinerId, GradingDataDto gradingData, bool isFinal);
        SubmissionDetailsViewModel GetSubmissionDetailsForExaminer(int submissionId, int examinerId);
    }
}