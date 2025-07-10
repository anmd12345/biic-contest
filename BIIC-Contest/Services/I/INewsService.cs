using BIIC_Contest.Dtos;
using BIIC_Contest.Entitys;
using System.Collections.Generic;

namespace BIIC_Contest.Services.I
{
    internal interface INewsService
    {
        BasicResponseEntity createNews(NewsDto newsDto);
        BasicResponseEntity getAllNews();
        BasicResponseEntity getNewsById(int id);
        BasicResponseEntity updateNews(NewsDto newsDto);
        BasicResponseEntity deleteNews(int id);
    }
}
