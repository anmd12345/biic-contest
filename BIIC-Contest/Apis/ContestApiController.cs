using BIIC_Contest.Constants;
using BIIC_Contest.Dtos;
using BIIC_Contest.Entitys;
using BIIC_Contest.Services;
using BIIC_Contest.Services.I;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.Mvc;

namespace BIIC_Contest.Apis
{
    [RoutePrefix("apis/v1/contest")]
    public class ContestApiController : Controller
    {
        private readonly IContestService contestService = new ContestService();

        [HttpPost]
        [Route("create")]
        [ValidateInput(false)]
        public JsonResult CreateContest()
        {
            var user = Session[SessionConstant.CURRENT_USER] as UserDto;
            if (user == null)
                return Json(new BasicResponseEntity(false, "Bạn chưa đăng nhập"));

            try
            {
                var request = this.HttpContext.Request;

                // --- Trường cơ bản ---
                string title = request.Form["Title"];
                string content = request.Form["Content"];
                bool isPriority = bool.Parse(request.Form["IsPriority"]);
                short status = short.Parse(request.Form["Status"]);

                // --- Trường mở rộng ---
                string rule = request.Form["Rule"];
                string prize = request.Form["Prize"];
                string schedule = request.Form["Schedule"];
                string sponsorsText = request.Form["Sponsors"];
                string criterias = request.Form["Criterias"];
                string beginTime = request.Form["BeginTime"];
                string endTime = request.Form["EndTime"];

                // --- Banner chính ---
                string bannerPath = "";
                var bannerFile = request.Files["Banner"];
                if (bannerFile != null && bannerFile.ContentLength > 0)
                {
                    string fileName = Path.GetFileName(bannerFile.FileName);
                    string relPath = "/assets/img/event/" + fileName;
                    string phyPath = Server.MapPath("~" + relPath);

                    Directory.CreateDirectory(Path.GetDirectoryName(phyPath));
                    bannerFile.SaveAs(phyPath);
                    bannerPath = relPath;
                }

                // --- Upload logo nhà tài trợ ---
                var sponsorFiles = request.Files.GetMultiple("SponsorLogos");
                List<string> sponsorLogoNames = new List<string>();

                if (sponsorFiles != null && sponsorFiles.Count > 0)
                {
                    foreach (var file in sponsorFiles)
                    {
                        if (file != null && file.ContentLength > 0 && file.FileName != null)
                        {
                            string fileName = Path.GetFileName(file.FileName);
                            string relPath = "/assets/img/sponsors/" + fileName;
                            string phyPath = Server.MapPath("~" + relPath);

                            Directory.CreateDirectory(Path.GetDirectoryName(phyPath));
                            file.SaveAs(phyPath);
                            sponsorLogoNames.Add(fileName);
                        }
                    }
                }


                // ---ghép chuôi tên ảnh logo nhà tài trợ ---
                if (sponsorLogoNames.Count > 0)
                {
                    sponsorsText = string.Join("|", sponsorLogoNames);
                }

                // --- AttachmentFiles () ---
                string attachmentPaths = "";
                var attachments = request.Files.GetMultiple("AttachmentFiles");

                if (attachments != null && attachments.Count > 0)
                {
                    foreach (var file in attachments)
                    {
                        if (file != null && file.ContentLength > 0)
                        {
                            string fileName = Path.GetFileName(file.FileName);
                            string fileExt = Path.GetExtension(fileName).ToLower();

                            string subFolder = fileExt == ".mp4" || fileExt == ".avi" || fileExt == ".mov" ? "videos" : "files";
                            string relativePath = $"/assets/upload/{subFolder}/";
                            string fullPath = Server.MapPath("~" + relativePath);
                            Directory.CreateDirectory(fullPath);

                            string fullSavePath = Path.Combine(fullPath, fileName);
                            file.SaveAs(fullSavePath);

                            // ✅ Chỉ lưu "files/abc.png"
                            attachmentPaths += $"{subFolder}/{fileName}|";
                        }
                    }

                    // ✅ Cắt bỏ dấu '|' cuối cùng nếu có
                    attachmentPaths = string.Join("|", attachmentPaths.Split('|').Where(p => !string.IsNullOrWhiteSpace(p)));
                }



                var dto = new NewsDto
                {
                    Title = title,
                    Content = content,
                    CategoryId = 3,
                    BannerUrl = bannerPath,
                    UserId = user.UserId,
                    Status = status,
                    IsPriority = isPriority,

                    Rule = rule,
                    Prize = prize,
                    Schedule = schedule,
                    Sponsors = sponsorsText,
                    Criterias = criterias,
                    BeginTime = beginTime,
                    EndTime = endTime,
                    AttachmentFiles = attachmentPaths
                };

                var result = contestService.createContest(dto);
                return Json(result);
            }
            catch (Exception ex)
            {
                return Json(new BasicResponseEntity(false, "Lỗi khi tạo cuộc thi: " + ex.Message));
            }
        }

        [HttpPost]
        [Route("update")]
        [ValidateInput(false)]
        public JsonResult UpdateContest()
        {
            var user = Session[SessionConstant.CURRENT_USER] as UserDto;
            if (user == null)
                return Json(new BasicResponseEntity(false, "Bạn chưa đăng nhập"));

            try
            {
                var request = this.HttpContext.Request;

                int newsId = int.Parse(request.Form["NewsId"]);
                string title = request.Form["Title"];
                string content = request.Form["Content"];
                bool isPriority = bool.Parse(request.Form["IsPriority"]);
                short status = short.Parse(request.Form["Status"]);
                string rule = request.Form["Rule"];
                string prize = request.Form["Prize"];
                string schedule = request.Form["Schedule"];
                string sponsorsText = request.Form["Sponsors"];
                string criterias = request.Form["Criterias"];
                string beginTime = request.Form["BeginTime"];
                string endTime = request.Form["EndTime"];
                short categoryId = short.Parse(request.Form["CategoryId"]);
                string oldSponsorText = request.Form["OldSponsorLogos"]; // danh sách logo giữ lại


                // ✅ Lấy dữ liệu cũ
                var oldResult = contestService.getContestById(newsId);
                if (!oldResult.Success)
                    return Json(oldResult);

                var old = oldResult.Data as NewsDto;

                // ✅ Banner
                string bannerPath = old.BannerUrl ?? "";
                var bannerFile = request.Files["Banner"];
                if (bannerFile != null && bannerFile.ContentLength > 0)
                {
                    // Xoá banner cũ nếu tồn tại
                    if (!string.IsNullOrEmpty(old.BannerUrl))
                    {
                        var oldBannerPath = Server.MapPath("~" + old.BannerUrl);
                        if (System.IO.File.Exists(oldBannerPath)) System.IO.File.Delete(oldBannerPath);
                    }

                    string fileName = Path.GetFileName(bannerFile.FileName);
                    //string relPath = "/assets/img/event/" + fileName;
                    string relPath = fileName;
                    string phyPath = Server.MapPath("~" + relPath);
                    Directory.CreateDirectory(Path.GetDirectoryName(phyPath));
                    bannerFile.SaveAs(phyPath);
                    bannerPath = relPath;
                }

                // ✅ Logo nhà tài trợ
                // ✅ Logo nhà tài trợ
                var sponsorFiles = request.Files.GetMultiple("SponsorLogos");
                List<string> sponsorLogoNames = new List<string>();

                if (sponsorFiles != null && sponsorFiles.Count > 0)
                {
                    foreach (var file in sponsorFiles)
                    {
                        if (file != null && file.ContentLength > 0 && file.FileName != null)
                        {
                            string fileName = Path.GetFileName(file.FileName);
                            string relPath = "/assets/img/sponsors/" + fileName;
                            string phyPath = Server.MapPath("~" + relPath);
                            Directory.CreateDirectory(Path.GetDirectoryName(phyPath));
                            file.SaveAs(phyPath);
                            sponsorLogoNames.Add(fileName);
                        }
                    }
                }

                // ✅ Xử lý giữ/xoá logo cũ
                var keepLogos = oldSponsorText?.Split('|') ?? new string[0];
                var oldLogos = old.Sponsors?.Split('|') ?? new string[0];

                // ✅ Xoá logo cũ không còn giữ
                var logosToDelete = oldLogos.Except(keepLogos);
                foreach (var fileName in logosToDelete)
                {
                    var path = Server.MapPath("~/assets/img/sponsors/" + fileName);
                    if (System.IO.File.Exists(path)) System.IO.File.Delete(path);
                }

                // ✅ Gộp logo giữ lại + mới upload
                sponsorLogoNames.AddRange(keepLogos.Where(l => !sponsorLogoNames.Contains(l)));
                sponsorsText = string.Join("|", sponsorLogoNames.Where(l => !string.IsNullOrWhiteSpace(l)));





                // ✅ File đính kèm
                string attachmentPaths = (request.Form["RemainingAttachments"] ?? "").Trim('|');
                var attachments = request.Files.GetMultiple("AttachmentFiles");
                List<string> newAttachmentPaths = attachmentPaths.Split(new[] { '|' }, StringSplitOptions.RemoveEmptyEntries).ToList();

                if (attachments != null && attachments.Count > 0)
                {
                    foreach (var file in attachments)
                    {
                        if (file != null && file.ContentLength > 0)
                        {
                            string fileName = Path.GetFileName(file.FileName);
                            string fileExt = Path.GetExtension(fileName).ToLower();
                            string subFolder = fileExt == ".mp4" || fileExt == ".avi" || fileExt == ".mov" ? "videos" : "files";
                            string relativePath = $"/assets/upload/{subFolder}/";
                            string fullPath = Server.MapPath("~" + relativePath);
                            Directory.CreateDirectory(fullPath);
                            string fullSavePath = Path.Combine(fullPath, fileName);
                            file.SaveAs(fullSavePath);
                            newAttachmentPaths.Add(fileName); 
                        }
                    }
                }

                attachmentPaths = string.Join("|", newAttachmentPaths.Where(p => !string.IsNullOrWhiteSpace(p)));

                // ✅ Xóa file đính kèm cũ không còn giữ lại
                var oldAttachments = old.AttachmentFiles?.Split('|') ?? new string[0];
                var keptAttachments = newAttachmentPaths.Select(p => p.TrimStart('/')).ToList();

                var filesToDelete = oldAttachments
                    .Where(p => !keptAttachments.Contains(p.TrimStart('/')))
                    .ToList();

                foreach (var pathRel in filesToDelete)
                {
                    var fullPath = Server.MapPath("~" + pathRel);
                    if (System.IO.File.Exists(fullPath))
                        System.IO.File.Delete(fullPath);
                }



                // ✅ Gán vào DTO
                var dto = new NewsDto
                {
                    NewsId = newsId,
                    Title = title,
                    Content = content,
                    CategoryId = categoryId,
                    BannerUrl = bannerPath,
                    UserId = user.UserId,
                    Status = status,
                    IsPriority = isPriority,
                    Rule = rule,
                    Prize = prize,
                    Schedule = schedule,
                    Sponsors = sponsorsText,
                    Criterias = criterias,
                    BeginTime = beginTime,
                    EndTime = endTime,
                    AttachmentFiles = attachmentPaths
                };

                var result = contestService.updateContest(dto);
                return Json(result);
            }
            catch (Exception ex)
            {
                return Json(new BasicResponseEntity(false, "Lỗi khi cập nhật cuộc thi: " + ex.Message));
            }
        }

        [HttpPost]
        [Route("delete")]
        public JsonResult DeleteContest(int newsId)
        {
            var user = Session[SessionConstant.CURRENT_USER] as UserDto;
            if (user == null)
                return Json(new BasicResponseEntity(false, "Bạn chưa đăng nhập"));

            try
            {
                // Lấy cuộc thi hiện có
                var result = contestService.getContestById(newsId);
                if (!result.Success)
                    return Json(result);

                var old = result.Data as NewsDto;

                // Xóa banner nếu có
                if (!string.IsNullOrEmpty(old.BannerUrl))
                {
                    var bannerPath = Server.MapPath("~" + old.BannerUrl);
                    if (System.IO.File.Exists(bannerPath))
                        System.IO.File.Delete(bannerPath);
                }

                // Xóa logo nhà tài trợ
                var sponsorLogos = old.Sponsors?.Split('|') ?? new string[0];
                foreach (var logo in sponsorLogos)
                {
                    var path = Server.MapPath("~/assets/img/sponsors/" + logo);
                    if (System.IO.File.Exists(path))
                        System.IO.File.Delete(path);
                }

                // Xóa các file đính kèm
                var attachments = old.AttachmentFiles?.Split('|') ?? new string[0];
                foreach (var file in attachments)
                {
                    var filePath = Server.MapPath("~/" + file);
                    if (System.IO.File.Exists(filePath))
                        System.IO.File.Delete(filePath);
                }

                // Gọi service để xoá bản ghi trong DB
                var deleteResult = contestService.deleteContest(newsId);
                return Json(deleteResult);
            }
            catch (Exception ex)
            {
                return Json(new BasicResponseEntity(false, "Lỗi khi xoá cuộc thi: " + ex.Message));
            }
        }



    }
}
