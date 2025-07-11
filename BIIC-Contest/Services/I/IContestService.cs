using BIIC_Contest.Dtos;
using BIIC_Contest.Entitys;

namespace BIIC_Contest.Services.I
{
    public interface IContestService
    {
        BasicResponseEntity createContest(NewsDto dto);
        // Các hàm mở rộng sau nếu cần: getAllContests, updateContest, ...
    }
}
