using AriBilgi.Blog.Data.Abstract;
using AriBilgi.Blog.Entities.Concrete;
using AriBilgi.Blog.Entities.Dtos;
using AriBilgi.Blog.Entities.Mapping;
using AriBilgi.Blog.Service.Abstract;
using AriBilgi.Blog.Shared.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AriBilgi.Blog.Service.Concrete
{
    public class ArticleManager : IArticleService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ArticleManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Result Add(ArticleAddDto article)
        {

            try
            {
                _unitOfWork.Articles.AddAsync(article.ToEntity());
                _unitOfWork.SaveAsync();
                return new Result(200, new List<string>() { "Makale başarıyla eklenmiştir," });
            }
            catch (Exception ex)
            {

                return new Result(500, new List<string>() { "Makale eklenirken teknik hata oluştu." }, ex);
            }

        }

        public Result Update(ArticleUpdateDto article, int articleId)
        {

            try
            {
                Article currentArticle = _unitOfWork.Articles.GetAsync(a => a.Id == articleId);

                currentArticle.Title = article.Title;
                currentArticle.Content = article.Content;
                currentArticle.ModifedBy = 1;
                currentArticle.ModifedDate = DateTime.Now;

                _unitOfWork.Articles.UpdateAsync(currentArticle);
                _unitOfWork.SaveAsync();

                return new Result(200, new List<string>() { "Makale başarıyla güncellenmiştir." });
            }
            catch (Exception ex)
            {

                return new Result(200, new List<string>() { "Makale güncellenirken teknik bir hata oluşmuştur." }, ex);
            }


        }

        public Result Remove(ArticleRemoveDto article)
        {
            try
            {
                Article currentArticle = _unitOfWork.Articles.GetAsync(a => a.Id == article.Id);

                _unitOfWork.Articles.HardDeleteAsync(currentArticle);

                _unitOfWork.SaveAsync();

                return new Result(200, new List<string>() { "Makale başarıyla silinmiştir." });
            }
            catch (Exception ex)
            {

                return new Result(500, new List<string>() { "Makale silinirken teknik bir hata oluşmuştur." }, ex);
            }
        }

        private IEnumerable<ArticleDto> GetAllQuery()
        {
            return (from a in _unitOfWork.Articles.GetAllAsync()
                    join c in _unitOfWork.Categories.GetAllAsync() on a.CategoryId equals c.Id
                    join u in _unitOfWork.Users.GetAllAsync() on a.UserId equals u.Id
                   
                    select new ArticleDto
                    {
                        Id = a.Id,
                        CategoryId = a.CategoryId,
                        Content = a.Content,
                        Category = c.ToDto(),
                        Title = a.Title,
                        User = u.ToDto(),
                        Comments=_unitOfWork.Comments.GetAllAsync(c=>c.ArticleId==a.Id).ToDto().ToList(),
                        CreatedDate=a.CreatedDate,
                        CommentCount = _unitOfWork.Comments.CountAsync(c => c.ArticleId == a.Id)
                    }).AsEnumerable<ArticleDto>();
        }

        public DataResult<List<ArticleDto>> GetAll()
        {
            var articles = GetAllQuery().ToList();

            if (articles.Count > 0)
            {
                return new DataResult<List<ArticleDto>>(200, articles, null);
            }
            else
            {
                return new DataResult<List<ArticleDto>>(200, null, new List<string>() { "Veritabanında kayıt bulunumadı" }, null);
            }
        }

        public DataResult<ArticleDto> Get(ArticleGetDto articleGetDto)
        {
            try
            {
                
            var articles=GetAllQuery().Where(x => x.Id == articleGetDto.Id).FirstOrDefault();

                return new DataResult<ArticleDto>(200, articles, null);
            }
            catch (Exception ex)
            {
                return new DataResult<ArticleDto>(500, null, new List<string>() { "Teknik bir hata oluştu" }, ex);
            }
        }

        public DataResult<ArticleDto> GetLastArticle()
        {
            try
            {
                var result = _unitOfWork.Articles.GetLastArticleByDate().ToDto();
                return new DataResult<ArticleDto>(200, result, new List<string> { "Başarılı" });
            }
            catch (Exception )
            {

                throw;
            }
        }
        public DataResult<List<ArticleDto>> GetAllByCategoryId(int categoryId)
        {
            try
            {

                var articles = GetAllQuery().Where(x => x.CategoryId ==categoryId).ToList();

                return new DataResult<List<ArticleDto>>(200, articles, null);
            }
            catch (Exception ex)
            {
                return new DataResult<List<ArticleDto>>(200, null, new List<string>() { "Teknik bir hata oluştu" }, ex);
            }
        }

        public DataResult<List<ArticleDto>> GetAllLastArticle(int count)
        {
            try
            {
                var articles = GetAllQuery().OrderByDescending(x => x.CreatedDate).Skip(1).Take(count).ToList();

                return new DataResult<List<ArticleDto>>(200, articles, new List<string> { "Başarılı" });
            }
            catch (Exception )
            {

                throw;
            }


        }
    }
}
