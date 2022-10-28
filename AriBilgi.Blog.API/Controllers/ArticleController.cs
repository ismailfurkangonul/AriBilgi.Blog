using AriBilgi.Blog.Data.Concrete;
using AriBilgi.Blog.Entities.Dtos;
using AriBilgi.Blog.Service.Concrete;
using AriBilgi.Blog.Shared.Result;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace AriBilgi.Blog.API.Controllers
{
    [ApiController]
    [Route("Api/[controller]")]
    public class ArticleController : ControllerBase
    {
        ArticleManager articleManager;
        public ArticleController()
        {
            articleManager = new ArticleManager(new UnitOfWork());
        }


        [HttpGet]
        [Route("ArticleGet")]
        public DataResult<ArticleDto> ArticleList(int articleId)
        {
            return articleManager.Get(new ArticleGetDto { Id = articleId });
        }

        [HttpGet]
        [Route("LastArticleGet")]
        public DataResult<ArticleDto> LastArticleGet()
        {
            return articleManager.GetLastArticle();
        }

        [HttpGet]
        [Route("ArticleList")]
        public DataResult<List<ArticleDto>> ArticleList()
        {
            return articleManager.GetAll();
        }

        [HttpGet]
        [Route("GetAllByCategory")]
        public DataResult<List<ArticleDto>> GetAllByCategory(int categoryId)
        {
            return articleManager.GetAllByCategoryId(categoryId);
        }


        [HttpGet]
        [Route("ArticleLastList")]
        public DataResult<List<ArticleDto>> ArticleLastList(int count)
        {
            return articleManager.GetAllLastArticle(count);
        }

        [HttpPost]
        [Route("ArticleAdd")]
        public Result ArticleAdd([FromBody]ArticleAddDto articleAddDto)
        {
            return articleManager.Add(articleAddDto);
        }

        [HttpPut]
        [Route("ArticleUpdate")]
        public Result ArticleUpdate([FromBody]ArticleUpdateDto articleUpdateDto, int articleId)
        {
            return articleManager.Update(articleUpdateDto, articleId);
        }

        [HttpPost]
        [Route("ArticleRemove")]
        public Result ArticleRemove(ArticleRemoveDto articleRemoveDto)
        {
            return articleManager.Remove(articleRemoveDto);
        }
    }
}
