using AriBilgi.Blog.Entities.Dtos;
using AriBilgi.Blog.Shared.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AriBilgi.Blog.Service.Abstract
{
    public interface ICategoryService
    {
        DataResult<CategoryDto> Get(CategoryGetDto categoryGetDto);

        DataResult<List<CategoryDto>> GetAll();

        Result Add(CategoryAddDto categoryAddDto);

        Result Remove(CategoryRemoveDto categoryRemoveDto);

        Result Update(CategoryUpdateDto categoryUpdateDto, int categoryId);
    }
}
