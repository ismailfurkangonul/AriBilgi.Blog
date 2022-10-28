using AriBilgi.Blog.Shared.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AriBilgi.Blog.Entities.Concrete
{
    public class Comment : EntityBase, IEntity
    {
        public string Content { get; set; }
        public int? UserId { get; set; }
        public int ArticleId { get; set; }

        public User User { get; set; }
        public Article Article { get; set; }

    }
}
