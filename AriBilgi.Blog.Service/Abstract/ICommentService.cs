using AriBilgi.Blog.Entities.Dtos;
using AriBilgi.Blog.Shared.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AriBilgi.Blog.Service.Abstract
{
    public interface ICommentService
    {
        Result Add(CommentAddDto commentAddDto);
        DataResult<List<CommentDto>> GetAll(CommentGetDto commentGetDto);
    }
}
