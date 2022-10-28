using AriBilgi.Blog.Data.Abstract;
using AriBilgi.Blog.Data.Concrete.EntityFramework.Contexts;
using AriBilgi.Blog.Entities.Concrete;
using AriBilgi.Blog.Shared.Data.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AriBilgi.Blog.Data.Concrete.EntityFramework.Repository
{
    public class ArticleRepository : Repository<Article>, IArticleRepository
    {
        private readonly BlogContext _context;
        public ArticleRepository(DbContext context) : base(context)
        {
            _context = new BlogContext();
        }

        public Article GetLastArticleByDate()
        {
           return _context.Articles.OrderByDescending(x => x.CreatedDate).FirstOrDefault();
        }
    }
}
