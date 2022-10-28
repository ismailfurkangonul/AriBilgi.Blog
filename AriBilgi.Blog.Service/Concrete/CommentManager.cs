using AriBilgi.Blog.Data.Abstract;
using AriBilgi.Blog.Entities.Concrete;
using AriBilgi.Blog.Entities.Dtos;
using AriBilgi.Blog.Service.Abstract;
using AriBilgi.Blog.Shared.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AriBilgi.Blog.Service.Concrete
{
    public class CommentManager : ICommentService
    {
        private IUnitOfWork _unitOfWork;

        public CommentManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Result Add(CommentAddDto commentAddDto)
        {
            try
            {
                _unitOfWork.Comments.AddAsync(new Comment
                {
                    Content = commentAddDto.Content,
                    ArticleId = commentAddDto.ArticleId,
                    UserId = commentAddDto.UserId
                });
                _unitOfWork.SaveAsync();

                return new Result(200, new List<string> { "Yorum başarıyla eklendi." });
            }
            catch (Exception ex)
            {
                return new Result(200, new List<string> { "Yorum eklenirken teknik bir hata oluştu." }, ex);
            }
        }

        public DataResult<List<CommentDto>> GetAll(CommentGetDto commentGetDto)
        {
            try
            {
                var comments = _unitOfWork.Comments.GetAllAsync(c => c.ArticleId == commentGetDto.ArticleId);
                List<CommentDto> commentDtos = new();
                foreach (var item in comments)
                {
                    commentDtos.Add(new CommentDto
                    {
                        ArticleId = item.ArticleId,
                        Content = item.Content,
                        Id = item.Id,
                        UserId = item.UserId
                    });
                }
                return new DataResult<List<CommentDto>>(200, commentDtos, new List<string> { "Liste başarıyla getirildi." });
            }
            catch (Exception ex)
            {
                return new DataResult<List<CommentDto>>(200, null, new List<string> { "Sistemsel bir hata oluştu." }, ex);
            }
        }

       
    }
}
