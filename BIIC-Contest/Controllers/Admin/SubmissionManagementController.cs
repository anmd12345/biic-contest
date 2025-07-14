
﻿using BIIC_Contest.Databases;
using BIIC_Contest.Models;
using BIIC_Contest.Services;
using BIIC_Contest.Services.I;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace BIIC_Contest.Controllers.Admin
{
    public class SubmissionManagementController : BaseAdminController
    {
        private readonly ISubmissionService _service;

        public SubmissionManagementController()
        {
            _service = new SubmissionService(); 
        }

        [Route("quan-ly-ho-so-du-thi")]
        public ActionResult IndexSubmissionManagement(string field, string status, int page = 1, int pageSize = 5)
        {
            int totalRecords;
            var submissions = _service.GetPaged(field, status, page, pageSize, out totalRecords);

            

            ViewBag.Fields = submissions.Select(s => s.field).Distinct().ToList();
            ViewBag.Statuses = submissions.Select(s => s.status).Distinct().ToList();

            ViewBag.CurrentPage = page;
            ViewBag.TotalPages = (int)Math.Ceiling((double)totalRecords / pageSize);

            return View(submissions);
        }

        [Route("quan-ly-ho-so-du-thi/chi-tiet/{id}")]
        public ActionResult DetailsSubmissionManagement(int id)
        {
            var submission = _service.GetById(id);
            if (submission == null)
                return HttpNotFound();

            return View(submission);
        }

        [HttpPost]
        public ActionResult UpdateStatus(int id, string status)
        {
            _service.UpdateStatus(id, status, out string message);
            TempData["Message"] = message;
            return RedirectToAction("DetailsSubmissionManagement", new { id });
        }

        [HttpPost]
        public ActionResult UploadFile(int id, HttpPostedFileBase file)
        {
            string uploadPath = Server.MapPath("~/assets/upload/files");
            _service.UploadFile(id, file, uploadPath, out string message);
            TempData["Message"] = message;
            return RedirectToAction("DetailsSubmissionManagement", new { id });
        }

        [Route("dang-ky-du-thi")]
        public ActionResult CreateSubmissionManagement()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("dang-ky-du-thi")]
        public ActionResult CreateSubmissionManagement(tbl_submission model, HttpPostedFileBase file)
        {
            if (string.IsNullOrWhiteSpace(model.fullname) ||
                string.IsNullOrWhiteSpace(model.birth_day) ||
                string.IsNullOrWhiteSpace(model.phone) ||
                string.IsNullOrWhiteSpace(model.email) ||
                string.IsNullOrWhiteSpace(model.address) ||
                string.IsNullOrWhiteSpace(model.field) ||
                string.IsNullOrWhiteSpace(model.description))
            {
                TempData["Message"] = "Vui lòng nhập đầy đủ thông tin bắt buộc.";
                return View(model);
            }

            if (ModelState.IsValid)
            {
                string uploadPath = Server.MapPath("~/assets/upload/files");
                _service.Create(model, file, uploadPath, out string message);
                TempData["Message"] = message;

                return RedirectToAction("CreateSubmissionManagement");
            }

            TempData["Message"] = "Vui lòng kiểm tra lại thông tin.";
            return View(model);
        }

        [HttpPost]
        public ActionResult DeleteSubmissionManagement(int id)
        {
            string uploadPath = Server.MapPath("~/assets/upload/files");
            _service.Delete(id, uploadPath, out string message);
            TempData["Message"] = message;
            return RedirectToAction("IndexSubmissionManagement");
        }
    }
}
