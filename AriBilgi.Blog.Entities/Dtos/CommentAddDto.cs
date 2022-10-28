using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AriBilgi.Blog.Entities.Dtos
{
    public class CommentAddDto
    {
        public string Content { get; set; }
        public int? UserId { get; set; }
        public int ArticleId { get; set; }
    }
}
