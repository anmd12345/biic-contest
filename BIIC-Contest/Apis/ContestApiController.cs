using BIIC_Contest.Constants;
using BIIC_Contest.Dtos;
using BIIC_Contest.Entitys;
using BIIC_Contest.Services;
using BIIC_Contest.Services.I;
using System;
using System.Collections.Generic;
using System.IO;
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

                            // Xác định thư mục theo loại file
                            string subFolder = fileExt == ".mp4" || fileExt == ".avi" || fileExt == ".mov" ? "videos" : "files";
                            string relativePath = $"/assets/upload/{subFolder}/";
                            string fullPath = Server.MapPath("~" + relativePath);

                            // Tạo thư mục nếu chưa tồn tại
                            if (!Directory.Exists(fullPath))
                                Directory.CreateDirectory(fullPath);

                            // Lưu file
                            string fullSavePath = Path.Combine(fullPath, fileName);
                            file.SaveAs(fullSavePath);

                            // Ghép vào chuỗi lưu CSDL
                            attachmentPaths += relativePath + fileName + "|";
                        }
                    }

                    if (attachmentPaths.EndsWith("|"))
                        attachmentPaths = attachmentPaths.Substring(0, attachmentPaths.Length - 1);
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
    }
}
