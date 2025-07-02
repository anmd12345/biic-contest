using BIIC_Contest.Dtos;
using BIIC_Contest.Entitys;
using System.Collections.Generic;

namespace BIIC_Contest.Services.I
{
    internal interface ICategoryService
    {
        BasicResponseEntity getAll();
        
        BasicResponseEntity insert(string name, string description);
    }
}
