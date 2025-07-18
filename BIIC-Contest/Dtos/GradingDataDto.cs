using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BIIC_Contest.Dtos
{
    public class GradingDataDto
    {
        public string OverallComment { get; set; }
        public int FinalScore { get; set; }
        public List<CriterionGradeDto> CriteriaGrades { get; set; }

        public GradingDataDto()
        {
            CriteriaGrades = new List<CriterionGradeDto>();
        }
    }

    public class CriterionGradeDto
    {
        public string Name { get; set; }
        public int Score { get; set; }
    }
}