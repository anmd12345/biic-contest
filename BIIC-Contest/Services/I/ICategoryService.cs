using BIIC_Contest.Entitys;
namespace BIIC_Contest.Services.I
{
    internal interface ICategoryService
    {
        BasicResponseEntity getAll();
        BasicResponseEntity insert(string name, string description);
        BasicResponseEntity update(short id, string name, string description);
        BasicResponseEntity delete(short id);
    }
}
