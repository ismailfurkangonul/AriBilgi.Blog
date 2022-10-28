using System;
using System.Collections.Generic;

namespace AriBilgi.Blog.Entities.Dtos
{
    public class ArticleDto
    {
        public int Id { get; set; }
    
        public string Title { get; set; }

        public string Content { get; set; }
        public int CommentCount { get; set; }
        public int CategoryId { get; set; }
        public int UserId { get; set; } = 1;
        public DateTime? CreatedDate { get; set; }

        public CategoryDto Category { get; set; }
        public UserDto User { get; set; }
        public ICollection<CommentDto> Comments { get; set; }
    }
}
