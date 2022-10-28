using AriBilgi.Blog.Data.Concrete;
using AriBilgi.Blog.Entities.Dtos;
using AriBilgi.Blog.Service.Concrete;
using AriBilgi.Blog.Shared.Result;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace AriBilgi.Blog.API.Controllers
{
    [Route("Api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        CategoryManager categoryManager;
        public CategoryController()
        {
            categoryManager = new CategoryManager(new UnitOfWork());
        }

        [HttpPost]
        [Route("CategoryAdd")]
        public Result CategoryAdd([FromBody] CategoryAddDto categoryAddDto)
        {
            return categoryManager.Add(categoryAddDto);
        }

        [HttpGet]
        [Route("CategoryGet")]
        public DataResult<CategoryDto> CategoryGet(int Id)
        {
            return categoryManager.Get(new CategoryGetDto { Id = Id });
        }

        [HttpGet]
        [Route("CategoryGetList")]
        public DataResult<List<CategoryDto>> CategoryGetList()
        {
            return categoryManager.GetAll();
        }

        [HttpPost]
        [Route("CategoryRemove")]
        public Result CategoryRemove(CategoryRemoveDto categoryRemoveDto)
        {
            return categoryManager.Remove(categoryRemoveDto);
        }

        [HttpPut]
        [Route("CategoryUpdate")]
        public Result CategoryUpdate([FromBody]CategoryUpdateDto categoryUpdateDto,int categoryId)
        {
            return categoryManager.Update(categoryUpdateDto, categoryId);
        }
    }
}
