using BIIC_Contest.Dtos;
using BIIC_Contest.Entitys;

namespace BIIC_Contest.Services.I
{
    public interface IContestService
    {
        BasicResponseEntity createContest(NewsDto dto);
        BasicResponseEntity updateContest(NewsDto dto); // ✅ Hàm cập nhật cuộc thi

        BasicResponseEntity deleteContest(int id);
        BasicResponseEntity getAllContests(); // ✅ Nếu cần dùng ở view list

        BasicResponseEntity getContestById(int id);

    }
}
