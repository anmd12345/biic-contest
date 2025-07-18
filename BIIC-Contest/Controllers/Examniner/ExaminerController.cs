using BIIC_Contest.Constants;
using BIIC_Contest.Dtos;
using BIIC_Contest.Services.I;
using BIIC_Contest.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace BIIC_Contest.Controllers
{
    [RoutePrefix("examiner")]
    public class ExaminerController : BaseExaminerController
    {
        private readonly ISubmissionService _submissionService;

        // CẢI TIẾN 1: Service được "tiêm" vào qua constructor.
        // Điều này đòi hỏi bạn cần cài đặt một DI Container như Unity.Mvc5
        public ExaminerController(ISubmissionService submissionService)
        {
            _submissionService = submissionService;
        }

        [Route("dashboard")]
        public ActionResult Index()
        {
            return View();
        }

        [Route("submissions")]
        public ActionResult Assignments(string field, string status, int page = 1, int pageSize = 10)
        {
            int totalRecords;
            var submissions = _submissionService.GetPaged(field, status, page, pageSize, out totalRecords);

            ViewBag.Fields = submissions.Select(s => s.field).Distinct().ToList();
            ViewBag.Statuses = submissions.Select(s => s.status).Distinct().ToList();
            ViewBag.CurrentPage = page;
            ViewBag.TotalPages = (int)Math.Ceiling((double)totalRecords / pageSize);
            ViewBag.TotalRecords = totalRecords;
            ViewBag.SelectedField = field;
            ViewBag.SelectedStatus = status;

            return View(submissions);
        }

        [Route("submission/{id}")]
        public ActionResult Details(int id)
        {
            var currentUser = Session[SessionConstant.CURRENT_USER] as UserDto;
            var viewModel = _submissionService.GetSubmissionDetailsForExaminer(id, currentUser.UserId);

            if (viewModel == null || viewModel.Submission == null)
            {
                return HttpNotFound();
            }

            return View(viewModel);
        }

        // CẢI TIẾN 2: Action mới để nhận dữ liệu từ form chấm điểm chi tiết
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("submission/save-grading")]
        public ActionResult SaveGrading(int submissionId, GradingDataDto gradingData, string submitButton)
        {
            var currentUser = Session[SessionConstant.CURRENT_USER] as UserDto;
            bool isFinal = (submitButton == "final");

            _submissionService.SaveGradingResult(submissionId, currentUser.UserId, gradingData, isFinal);

            TempData["Message"] = isFinal ? "Nộp điểm thành công!" : "Lưu nháp thành công!";
            return RedirectToAction("Details", new { id = submissionId });
        }
    }
}