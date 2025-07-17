using BIIC_Contest.Constants;
using BIIC_Contest.Databases;
using BIIC_Contest.Dtos;
using BIIC_Contest.Services;
using BIIC_Contest.Services.I;
using System;
using System.Linq;
using System.Web.Mvc;

namespace BIIC_Contest.Controllers
{
    // Sử dụng RoutePrefix để định nghĩa tiền tố chung cho tất cả các action bên trong
    [RoutePrefix("examiner")]
    public class ExaminerController : BaseExaminerController
    {
        private readonly ISubmissionService _submissionService;

        public ExaminerController()
        {
            _submissionService = new SubmissionService();
        }

        // Action này sẽ tương ứng với URL: "examiner/dashboard"
        [Route("dashboard")]
        public ActionResult Index()
        {
            return View();
        }

        // Action này sẽ tương ứng với URL: "examiner/submissions"
        // Sửa lại Route cho đúng với chức năng của Action
        [Route("submissions")]
        public ActionResult Assignments(string field, string status, int page = 1, int pageSize = 10)
        {
            int totalRecords;
            var submissions = _submissionService.GetPaged(field, status, page, pageSize, out totalRecords);

            ViewBag.Fields = submissions.Select(s => s.field).Distinct().ToList();
            ViewBag.Statuses = submissions.Select(s => s.status).Distinct().ToList();

            ViewBag.CurrentPage = page;
            ViewBag.TotalPages = (int)Math.Ceiling((double)totalRecords / pageSize);
            ViewBag.PageSize = pageSize;
            ViewBag.TotalRecords = totalRecords;
            ViewBag.SelectedField = field;
            ViewBag.SelectedStatus = status;

            return View(submissions);
        }

        // Action này sẽ tương ứng với URL: "examiner/submission/{id}"
        [Route("submission/{id}")]
        public ActionResult Details(int id)
        {
            var submission = _submissionService.GetById(id);
            if (submission == null)
            {
                return HttpNotFound();
            }
            return View(submission);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateStatus(int submissionId, string status) // Giữ nguyên nếu chỉ cập nhật status
                                                                          // Hoặc public ActionResult UpdateStatus(int submissionId, string status, int? score, string feedback) // Nếu có thêm điểm và nhận xét
        {
            // Gọi đến service để cập nhật status (và các trường khác nếu có)
            _submissionService.UpdateStatus(submissionId, status, out string message);

            TempData["Message"] = message;

            return RedirectToAction("Details", new { id = submissionId });
        }
    }
}