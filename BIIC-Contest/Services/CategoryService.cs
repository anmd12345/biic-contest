using BIIC_Contest.Constants;
using BIIC_Contest.Dtos;
using BIIC_Contest.Entitys;
using BIIC_Contest.Helpers;
using BIIC_Contest.Models;
using BIIC_Contest.Repositorys;
using BIIC_Contest.Services.I;
using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace BIIC_Contest.Services
{
    public class CategoryService : IBaseService, ICategoryService
    {

        private CategoryRepository repo = new CategoryRepository();

        public BasicResponseEntity delete(short id)
        {
            bool response = repo.delete(id);
            
            if (!response)
            {
                return new BasicResponseEntity
                {
                    Success = false,
                    Message = MessageConstant.CategoryMessage[8],
                    Data = null
                };
            }

            return new BasicResponseEntity
            {
                Success = true,
                Message = MessageConstant.CategoryMessage[9],
                Data = null
            };
        }

        public BasicResponseEntity getAll()
        {
            List<tbl_category> categories = repo.findAll();

            if(categories.Count == 0)
            {
                return new BasicResponseEntity
                {
                    Success = false,
                    Message = MessageConstant.CategoryMessage[4],
                    Data = null
                };
            }

            var data = toDtos(categories);


            return new BasicResponseEntity
            {
                Success = true,
                Message = MessageConstant.CategoryMessage[5],
                Data = data
            };
        }

        public BasicResponseEntity insert(string name, string description)
        {
            if(ValidateDataHelper.isNullOrEmpty(name))
            {
                return new BasicResponseEntity
                {
                    Success = false,
                    Message = MessageConstant.CategoryMessage[1],
                    Data = null
                };
            }

            if (repo.isExist(name))
            {
                return new BasicResponseEntity
                {
                    Success = false,
                    Message = MessageConstant.CategoryMessage[0],
                    Data = null
                };
            }

            bool insertResponse = repo.insert(name, description);

            if (!insertResponse)
            {
                return new BasicResponseEntity
                {
                    Success = false,
                    Message = MessageConstant.CategoryMessage[3],
                    Data = null
                };
            }

            return new BasicResponseEntity
            {
                Success = true,
                Message = MessageConstant.CategoryMessage[2],
                Data = new CategoryDto
                {
                    CategoryName = name,
                    Description = description
                }
            };
        }

        public dynamic toDto(dynamic model)
        {
            tbl_category category = model as tbl_category;

            if (category != null)
            {
                return new CategoryDto
                {
                    Id = category.category_id,
                    CategoryName = category.category_name,
                    Description = category.description
                };
            }

            return null;
        }

        public dynamic toDtos(dynamic models)
        {
            List<tbl_category> categories = models as List<tbl_category>;
            List<CategoryDto> dtos = new List<CategoryDto>();

            if (categories.Count > 0)
            {
                foreach (var category in categories)
                {
                    dtos.Add(toDto(category));
                }
            }

            return dtos;
        }

        public dynamic toModel(dynamic dto)
        {
            throw new NotImplementedException();
        }

        public dynamic toModels(dynamic dtos)
        {
            throw new NotImplementedException();
        }

        public BasicResponseEntity update(short id, string name, string description)
        {
            if (ValidateDataHelper.isNullOrEmpty(name))
            {
                return new BasicResponseEntity
                {
                    Success = false,
                    Message = MessageConstant.CategoryMessage[1],
                    Data = null
                };
            }

            if (repo.isExist(name))
            {
                return new BasicResponseEntity
                {
                    Success = false,
                    Message = MessageConstant.CategoryMessage[0],
                    Data = null
                };
            }


            bool response = repo.update(id, name, description);

            if (!response)
            {
                return new BasicResponseEntity
                {
                    Success = false,
                    Message = MessageConstant.CategoryMessage[7],
                    Data = null
                };
            }

            return new BasicResponseEntity
            {
                Success = true,
                Message = MessageConstant.CategoryMessage[6],
                Data = new CategoryDto
                {
                    CategoryName = name,
                    Description = description
                }
            };
        }
    }
}