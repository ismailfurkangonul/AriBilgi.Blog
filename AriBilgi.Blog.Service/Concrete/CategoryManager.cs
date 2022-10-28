using AriBilgi.Blog.Data.Abstract;
using AriBilgi.Blog.Entities.Concrete;
using AriBilgi.Blog.Entities.Dtos;
using AriBilgi.Blog.Entities.Mapping;
using AriBilgi.Blog.Service.Abstract;
using AriBilgi.Blog.Shared.Result;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AriBilgi.Blog.Service.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CategoryManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Result Add(CategoryAddDto categoryAddDto)
        {
            try
            {
                _unitOfWork.Categories.AddAsync(categoryAddDto.ToEntity());
                _unitOfWork.SaveAsync();

                return new Result(200, new List<string> { "Kategori başarıyla eklenmiştir" });
            }
            catch (Exception ex)
            {
                return new Result(500, new List<string> { "Kategori eklenirken sistemsel bir hata oluştu." }, ex);
            }
        }

        public DataResult<CategoryDto> Get(CategoryGetDto categoryGetDto)
        {
            try
            {
                Category category = _unitOfWork.Categories.GetAsync(x => x.Id == categoryGetDto.Id);


                return new DataResult<CategoryDto>(200, category.ToDto(), null);

            }
            catch (Exception ex)
            {

                return new DataResult<CategoryDto>(200, null, new List<string>() { "Teknik bir hata oluştu." }, ex);
            }
        }

        public DataResult<List<CategoryDto>> GetAll()
        {
            try
            {
                List<Category> category = _unitOfWork.Categories.GetAllAsync();
                return new DataResult<List<CategoryDto>>(200, category.ToDto().ToList(), null);

            }
            catch (Exception ex)
            {

                return new DataResult<List<CategoryDto>>(200, null, new List<string>() { "Teknik bir hata oluştu." }, ex);
            }
        }

        public Result Remove(CategoryRemoveDto categoryRemoveDto)
        {
            try
            {
                var category = _unitOfWork.Categories.GetAsync(c => c.Id == categoryRemoveDto.Id);
                if (category != null)
                {
                    _unitOfWork.Categories.HardDeleteAsync(category);
                    _unitOfWork.SaveAsync();

                    return new Result(200, new List<string> { "Kategori başarıyla silinmiştir." });
                }
                return new Result(200, new List<string> { "Silmek istediğiniz kategori bulunumadı." });
            }
            catch (Exception ex)
            {

                return new Result(500, new List<string> { "Teknik bir sorun oluştu." }, ex);
            }

        }

        public Result Update(CategoryUpdateDto categoryUpdateDto, int categoryId)
        {
            try
            {
                var category = _unitOfWork.Categories.GetAsync(c => c.Id == categoryId);
                if (category != null)
                {
                    category.Title = categoryUpdateDto.Title;
                    category.Content = categoryUpdateDto.Content;
                    category.ModifedBy = 1;
                    category.ModifedDate = DateTime.Now;


                    _unitOfWork.Categories.UpdateAsync(category);
                    _unitOfWork.SaveAsync();

                    return new Result(200, new List<string> { "Kategori başarıyla güncellenmiştir." });
                }
                return new Result(200, new List<string> { "Güncellemek istediğiniz kategori bulunumadı." });
            }
            catch (Exception ex)
            {

                return new Result(500, new List<string> { "Teknik bir sorun oluştu." }, ex);
            }
        }
    }
}
