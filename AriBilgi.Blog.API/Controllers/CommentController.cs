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
    public class CommentController : ControllerBase
    {
        CommentManager commentManager;
        public CommentController()
        {
            commentManager = new CommentManager(new UnitOfWork());
        }

        [HttpPost]
        [Route("CommentAdd")]
        public Result CommentAdd(CommentAddDto commentAddDto)
        {
            return commentManager.Add(commentAddDto);
        }


        [HttpPost]
        [Route("CommentGetAll")]
        public DataResult<List<CommentDto>> CommentGetAll(CommentGetDto commentGetDto)
        {
            return commentManager.GetAll(commentGetDto);
        }

    }
}
