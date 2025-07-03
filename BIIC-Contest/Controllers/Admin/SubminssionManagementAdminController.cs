<<<<<<< HEAD
﻿using BIIC_Contest.Databases;
using BIIC_Contest.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Configuration;


namespace BIIC_Contest.Controllers.Admin
{
    public class SubminssionManagementAdminController : Controller
    {
        private readonly BIICConnectionDbDataContext db = new BIICConnectionDbDataContext(
    System.Configuration.ConfigurationManager.ConnectionStrings["biic_contest_dbConnectionString"].ConnectionString
);



        public ActionResult IndexSubminssionManagement(string field, string status, int page = 1, int pageSize = 10)
        {
            var submissions = db.tbl_submissions.AsQueryable();

            if (!string.IsNullOrEmpty(field))
                submissions = submissions.Where(x => x.field == field);

            if (!string.IsNullOrEmpty(status))
            {
                short parsedStatus;
                if (short.TryParse(status, out parsedStatus))
                {
                    submissions = submissions.Where(x => x.status == parsedStatus);
                }
            }


            int totalRecords = submissions.Count();
            var pagedData = submissions
                .OrderBy(x => x.submission_id)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            ViewBag.Fields = db.tbl_submissions
                .Where(s => s.field != null)
                .Select(s => s.field)
                .Distinct()
                .ToList();

            ViewBag.Statuses = db.tbl_submissions
                .Where(s => s.status != null)
                .Select(s => s.status)
                .Distinct()
                .ToList();

            ViewBag.CurrentPage = page;
            ViewBag.TotalPages = (int)Math.Ceiling((double)totalRecords / pageSize);

            return View(pagedData);
        }

        public ActionResult DetailsSubminssionManagement(int id)
        {
            var submission = db.tbl_submissions.FirstOrDefault(x => x.submission_id == id);
            if (submission == null)
                return HttpNotFound();
            return View(submission);
        }

        [HttpPost]
        public ActionResult UpdateStatus(int id, string status)
        {
            var submission = db.tbl_submissions.FirstOrDefault(x => x.submission_id == id);
            if (submission != null)
            {
                short parsedStatus;
                if (short.TryParse(status, out parsedStatus))
                {
                    submission.status = parsedStatus;
                    db.SubmitChanges();
                    TempData["Message"] = "Cập nhật trạng thái thành công.";
                }
                else
                {
                    TempData["Message"] = "Trạng thái không hợp lệ.";
                }
            }
            else
            {
                TempData["Message"] = "Không tìm thấy hồ sơ.";
            }

            return RedirectToAction("DetailsSubminssionManagement", new { id });
        }


        [HttpPost]
        public ActionResult UploadFile(int id, HttpPostedFileBase file)
        {
            var submission = db.tbl_submissions.FirstOrDefault(x => x.submission_id == id);
            if (submission == null)
                return HttpNotFound();

            if (file != null && file.ContentLength > 0)
            {
                var fileName = Path.GetFileName(file.FileName);
                var uploadFolder = Server.MapPath("~/assets/upload/files");

                // Tạo thư mục nếu chưa tồn tại
                if (!Directory.Exists(uploadFolder))
                    Directory.CreateDirectory(uploadFolder);

                var path = Path.Combine(uploadFolder, fileName);
                file.SaveAs(path);

                // Nối thêm file vào danh sách file đính kèm
                if (string.IsNullOrEmpty(submission.submisstion_files))
                    submission.submisstion_files = fileName;
                else
                    submission.submisstion_files += "," + fileName;

                db.SubmitChanges();
                TempData["Message"] = "Tải file lên thành công.";
            }
            else
            {
                TempData["Message"] = "Vui lòng chọn file để tải lên.";
            }

            return RedirectToAction("DetailsSubminssionManagement", new { id });
        }





        // GET: Create
        public ActionResult CreateSubminssionManagement()
        {
            return View();
        }

        // POST: Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateSubminssionManagement(tbl_submission model, HttpPostedFileBase file)
        {
            if (string.IsNullOrWhiteSpace(model.fullname) ||
                string.IsNullOrWhiteSpace(model.birth_day)||
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
                // Sinh mã bài dự thi ngẫu nhiên gồm 6 ký tự
                model.submission_code = GenerateRandomCode(6);

                // Xử lý file nếu có
                if (file != null && file.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(file.FileName);
                    var uploadPath = Server.MapPath("~/assets/upload/files");

                    if (!Directory.Exists(uploadPath))
                        Directory.CreateDirectory(uploadPath);

                    var path = Path.Combine(uploadPath, fileName);
                    file.SaveAs(path);

                    model.submisstion_files = fileName;
                }

                model.status = 1; // Mặc định "Đã tiếp nhận"
                db.tbl_submissions.InsertOnSubmit(model);
                db.SubmitChanges();

                TempData["Message"] = "Thêm hồ sơ thành công.";
                return RedirectToAction("IndexSubminssionManagement");

            }

            TempData["Message"] = "Vui lòng kiểm tra lại thông tin.";
            return View(model);
        }

        //ramdom 6 ký tự
        private static string GenerateRandomCode(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var random = new Random();
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }




        //xóa bài dự thi, xóa luôn file đính kèm 
        [HttpPost]
        public ActionResult DeleteSubminssionManagement(int id)
        {
            var submission = db.tbl_submissions.FirstOrDefault(x => x.submission_id == id);
            if (submission == null)
            {
                TempData["Message"] = "Không tìm thấy hồ sơ cần xóa.";
                return RedirectToAction("IndexSubminssionManagement");
            }

            // Xóa file đính kèm nếu có
            if (!string.IsNullOrEmpty(submission.submisstion_files))
            {
                var files = submission.submisstion_files.Split(',');
                foreach (var file in files)
                {
                    var filePath = Path.Combine(Server.MapPath("~/assets/upload/files"), file);
                    if (System.IO.File.Exists(filePath))
                    {
                        System.IO.File.Delete(filePath);
                    }
                }
            }

            // Xóa khỏi database
            db.tbl_submissions.DeleteOnSubmit(submission);
            db.SubmitChanges();

            TempData["Message"] = "Xóa hồ sơ thành công.";
            return RedirectToAction("IndexSubminssionManagement");
        }



    }
}
=======
﻿using BIIC_Contest.Databases;
using BIIC_Contest.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Configuration;


namespace BIIC_Contest.Controllers.Admin
{
    public class SubminssionManagementAdminController : Controller
    {
        private readonly BIICConnectionDbDataContext db = new BIICConnectionDbDataContext(
    System.Configuration.ConfigurationManager.ConnectionStrings["biic_contest_dbConnectionString"].ConnectionString
);



        public ActionResult IndexSubminssionManagement(string field, string status, int page = 1, int pageSize = 10)
        {
            var submissions = db.tbl_submissions.AsQueryable();

            if (!string.IsNullOrEmpty(field))
                submissions = submissions.Where(x => x.field == field);

            if (!string.IsNullOrEmpty(status))
            {
                short parsedStatus;
                if (short.TryParse(status, out parsedStatus))
                {
                    submissions = submissions.Where(x => x.status == parsedStatus);
                }
            }


            int totalRecords = submissions.Count();
            var pagedData = submissions
                .OrderBy(x => x.submission_id)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            ViewBag.Fields = db.tbl_submissions
                .Where(s => s.field != null)
                .Select(s => s.field)
                .Distinct()
                .ToList();

            ViewBag.Statuses = db.tbl_submissions
                .Where(s => s.status != null)
                .Select(s => s.status)
                .Distinct()
                .ToList();

            ViewBag.CurrentPage = page;
            ViewBag.TotalPages = (int)Math.Ceiling((double)totalRecords / pageSize);

            return View(pagedData);
        }

        public ActionResult DetailsSubminssionManagement(int id)
        {
            var submission = db.tbl_submissions.FirstOrDefault(x => x.submission_id == id);
            if (submission == null)
                return HttpNotFound();
            return View(submission);
        }

        [HttpPost]
        public ActionResult UpdateStatus(int id, string status)
        {
            var submission = db.tbl_submissions.FirstOrDefault(x => x.submission_id == id);
            if (submission != null)
            {
                short parsedStatus;
                if (short.TryParse(status, out parsedStatus))
                {
                    submission.status = parsedStatus;
                    db.SubmitChanges();
                    TempData["Message"] = "Cập nhật trạng thái thành công.";
                }
                else
                {
                    TempData["Message"] = "Trạng thái không hợp lệ.";
                }
            }
            else
            {
                TempData["Message"] = "Không tìm thấy hồ sơ.";
            }

            return RedirectToAction("DetailsSubminssionManagement", new { id });
        }


        [HttpPost]
        public ActionResult UploadFile(int id, HttpPostedFileBase file)
        {
            var submission = db.tbl_submissions.FirstOrDefault(x => x.submission_id == id);
            if (submission == null)
                return HttpNotFound();

            if (file != null && file.ContentLength > 0)
            {
                var fileName = Path.GetFileName(file.FileName);
                var uploadFolder = Server.MapPath("~/assets/upload/files");

                // Tạo thư mục nếu chưa tồn tại
                if (!Directory.Exists(uploadFolder))
                    Directory.CreateDirectory(uploadFolder);

                var path = Path.Combine(uploadFolder, fileName);
                file.SaveAs(path);

                // Nối thêm file vào danh sách file đính kèm
                if (string.IsNullOrEmpty(submission.submisstion_files))
                    submission.submisstion_files = fileName;
                else
                    submission.submisstion_files += "," + fileName;

                db.SubmitChanges();
                TempData["Message"] = "Tải file lên thành công.";
            }
            else
            {
                TempData["Message"] = "Vui lòng chọn file để tải lên.";
            }

            return RedirectToAction("DetailsSubminssionManagement", new { id });
        }





        // GET: Create
        public ActionResult CreateSubminssionManagement()
        {
            return View();
        }

        // POST: Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateSubminssionManagement(tbl_submission model, HttpPostedFileBase file)
        {
            if (string.IsNullOrWhiteSpace(model.fullname) ||
                string.IsNullOrWhiteSpace(model.birth_day)||
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
                // Sinh mã bài dự thi ngẫu nhiên gồm 6 ký tự
                model.submission_code = GenerateRandomCode(6);

                // Xử lý file nếu có
                if (file != null && file.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(file.FileName);
                    var uploadPath = Server.MapPath("~/assets/upload/files");

                    if (!Directory.Exists(uploadPath))
                        Directory.CreateDirectory(uploadPath);

                    var path = Path.Combine(uploadPath, fileName);
                    file.SaveAs(path);

                    model.submisstion_files = fileName;
                }

                model.status = 1; // Mặc định "Đã tiếp nhận"
                db.tbl_submissions.InsertOnSubmit(model);
                db.SubmitChanges();

                TempData["Message"] = "Thêm hồ sơ thành công.";
                return RedirectToAction("IndexSubminssionManagement");

            }

            TempData["Message"] = "Vui lòng kiểm tra lại thông tin.";
            return View(model);
        }

        //ramdom 6 ký tự
        private static string GenerateRandomCode(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var random = new Random();
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }




        //xóa bài dự thi, xóa luôn file đính kèm 
        [HttpPost]
        public ActionResult DeleteSubminssionManagement(int id)
        {
            var submission = db.tbl_submissions.FirstOrDefault(x => x.submission_id == id);
            if (submission == null)
            {
                TempData["Message"] = "Không tìm thấy hồ sơ cần xóa.";
                return RedirectToAction("IndexSubminssionManagement");
            }

            // Xóa file đính kèm nếu có
            if (!string.IsNullOrEmpty(submission.submisstion_files))
            {
                var files = submission.submisstion_files.Split(',');
                foreach (var file in files)
                {
                    var filePath = Path.Combine(Server.MapPath("~/assets/upload/files"), file);
                    if (System.IO.File.Exists(filePath))
                    {
                        System.IO.File.Delete(filePath);
                    }
                }
            }

            // Xóa khỏi database
            db.tbl_submissions.DeleteOnSubmit(submission);
            db.SubmitChanges();

            TempData["Message"] = "Xóa hồ sơ thành công.";
            return RedirectToAction("IndexSubminssionManagement");
        }



    }
}
>>>>>>> 8a24273f6c10eaf21cb20f0ab6ddf4843ade553c
