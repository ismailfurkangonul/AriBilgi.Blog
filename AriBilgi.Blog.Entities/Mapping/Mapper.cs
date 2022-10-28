using AriBilgi.Blog.Entities.Concrete;
using AriBilgi.Blog.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AriBilgi.Blog.Entities.Mapping
{

    public static class Mapper
    {
        #region Article
        public static Article ToEntity(this ArticleAddDto articleAddDto)
        {
            return new Article { CategoryId = articleAddDto.CategoryId, Title = articleAddDto.Title, Content = articleAddDto.Content, UserId = articleAddDto.UserId };
        }

        public static ArticleDto ToDto(this Article article)
        {
            return new ArticleDto
            {
                Id = article.Id,
                CategoryId = article.CategoryId,
                Content = article.Content,
                Title = article.Title,
                UserId = article.UserId
            };
        }

        public static IEnumerable<ArticleDto> ToDto(this IEnumerable<Article> article)
        {
            return article.Select(a => a.ToDto());
        }
        #endregion

        #region Category
        public static Category ToEntity(this CategoryAddDto categoryAddDto)
        {
            return new Category
            {
                Title = categoryAddDto.Title,
                Content = categoryAddDto.Content
            };
        }
        public static CategoryDto ToDto(this Category category)
        {
            return new CategoryDto
            {
                Id = category.Id,
                Title = category.Title,
                Content = category.Content
            };
        }
        public static IEnumerable<CategoryDto> ToDto(this IEnumerable<Category> categoryList)
        {
            return categoryList.Select(c => c.ToDto());
        }
        #endregion

        #region User
        public static UserDto ToDto(this User user)
        {
            return new UserDto
            {
                Id = user.Id,
                Name = user.Name,
                Surname = user.Surname
            };
        }
        #endregion

        #region Comment
        public static CommentDto ToDto(this Comment comment)
        {
            return new CommentDto { Id = comment.Id, Content = comment.Content };
        }
        public static IEnumerable<CommentDto> ToDto(this IEnumerable<Comment> comment)
        {
            return comment.Select(c => c.ToDto());
        }

        #endregion

    }
}
