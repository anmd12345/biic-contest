using BIIC_Contest.Dtos;
using BIIC_Contest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BIIC_Contest.ViewModels
{
    public class SubmissionDetailsViewModel
    {
        // Dữ liệu chính: Thông tin chi tiết của bài thi
        public tbl_submission Submission { get; set; }
        public tbl_assignment Assignment { get; set; }

        // Dữ liệu phụ 1: Chuỗi tiêu chí hướng dẫn từ bảng phân công
        public string AssignmentRequirement { get; set; }

        public GradingDataDto GradingData { get; set; }
        public bool IsCompleted { get; set; }
    }
}