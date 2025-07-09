using BIIC_Contest.Models;
using BIIC_Contest.Repositorys;
using BIIC_Contest.Services.I;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace BIIC_Contest.Services
{
    public class SubmissionService : ISubmissionService
    {
        private readonly ISubmissionRepo _repo;

        public SubmissionService()
        {
            _repo = new SubmissionRepo(); // hoặc dùng DI
        }

        public IEnumerable<tbl_submission> GetPaged(string field, string status, int page, int pageSize, out int totalRecords)
        {
            var query = _repo.GetAll();

            if (!string.IsNullOrEmpty(field))
                query = query.Where(x => x.field == field);

            if (!string.IsNullOrEmpty(status) && short.TryParse(status, out short parsed))
                query = query.Where(x => x.status == parsed);

            totalRecords = query.Count();

            return query.OrderBy(x => x.submission_id)
                        .Skip((page - 1) * pageSize)
                        .Take(pageSize)
                        .ToList();
        }

        public tbl_submission GetById(int id) => _repo.GetById(id);

        public void UpdateStatus(int id, string status, out string message)
        {
            var submission = _repo.GetById(id);
            if (submission == null)
            {
                message = "Không tìm thấy hồ sơ.";
                return;
            }

            if (short.TryParse(status, out short parsed))
            {
                submission.status = parsed;
                _repo.Save();
                message = "Cập nhật trạng thái thành công.";
            }
            else
            {
                message = "Trạng thái không hợp lệ.";
            }
        }

        public void UploadFile(int id, HttpPostedFileBase file, string uploadPath, out string message)
        {
            var submission = _repo.GetById(id);
            if (submission == null)
            {
                message = "Không tìm thấy hồ sơ.";
                return;
            }

            if (file != null && file.ContentLength > 0)
            {
                var fileName = Path.GetFileName(file.FileName);
                if (!Directory.Exists(uploadPath))
                    Directory.CreateDirectory(uploadPath);

                var path = Path.Combine(uploadPath, fileName);
                file.SaveAs(path);

                submission.submisstion_files = string.IsNullOrEmpty(submission.submisstion_files)
                    ? fileName
                    : submission.submisstion_files + "," + fileName;

                _repo.Save();
                message = "Tải file lên thành công.";
            }
            else
            {
                message = "Vui lòng chọn file để tải lên.";
            }
        }

        public void Create(tbl_submission model, HttpPostedFileBase file, string uploadPath, out string message)
        {
            try
            {
                model.submission_code = GenerateRandomCode(6);
                if (file != null && file.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(file.FileName);
                    if (!Directory.Exists(uploadPath))
                        Directory.CreateDirectory(uploadPath);

                    var path = Path.Combine(uploadPath, fileName);
                    file.SaveAs(path);
                    model.submisstion_files = fileName;
                }

                model.status = 1;
                _repo.Insert(model);
                _repo.Save();
                message = "BẠN ĐÃ ĐĂNG KÝ CUỘC THI THÀNH CÔNG.";
            }
            catch (Exception ex)
            {
                message = "Lỗi khi thêm hồ sơ: " + ex.Message;
            }
        }


        public void Delete(int id, string uploadPath, out string message)
        {
            var submission = _repo.GetById(id);
            if (submission == null)
            {
                message = "Không tìm thấy hồ sơ cần xóa.";
                return;
            }

            if (!string.IsNullOrEmpty(submission.submisstion_files))
            {
                var files = submission.submisstion_files.Split(',');
                foreach (var file in files)
                {
                    var filePath = Path.Combine(uploadPath, file);
                    if (System.IO.File.Exists(filePath))
                        System.IO.File.Delete(filePath);
                }
            }

            _repo.Delete(submission);
            _repo.Save();
            message = "Xóa hồ sơ thành công.";
        }

        private static string GenerateRandomCode(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var random = new Random();
            return new string(Enumerable.Repeat(chars, length).Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public bool IsEmailExists(string email)
        {
            return _repo.GetAll().Any(x => x.email == email);
        }

    }
}