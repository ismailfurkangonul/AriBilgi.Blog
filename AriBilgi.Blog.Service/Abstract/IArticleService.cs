using AriBilgi.Blog.Entities.Dtos;
using AriBilgi.Blog.Shared.Result;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace AriBilgi.Blog.Service.Abstract
{
    public interface IArticleService
    {
        Result Add(ArticleAddDto article);
        Result Update(ArticleUpdateDto article, int articleId);
        Result Remove(ArticleRemoveDto article);
        DataResult<ArticleDto> Get(ArticleGetDto articleGetDto);
        DataResult<List<ArticleDto>> GetAll();
        DataResult<ArticleDto> GetLastArticle();
        DataResult<List<ArticleDto>> GetAllLastArticle(int count);
    }
}
