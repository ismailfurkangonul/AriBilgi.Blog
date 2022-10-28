using AriBilgi.Blog.Data.Abstract;
using AriBilgi.Blog.Data.Concrete.EntityFramework.Contexts;
using AriBilgi.Blog.Data.Concrete.EntityFramework.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AriBilgi.Blog.Data.Concrete
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BlogContext _context;
        private readonly ArticleRepository _articleRepository;
        private readonly CategoryRepository _categoryRepository;
        private readonly CommentRepository _commentRepository;
        private readonly UserRepository _userRepository;
        private readonly UserRoleRepository _userRoleRepository;

        public UnitOfWork()
        {
            _context = new BlogContext();
        }

        public IArticleRepository Articles => _articleRepository ?? new ArticleRepository(_context);

        public ICategoryRepository Categories => _categoryRepository ?? new CategoryRepository(_context);

        public ICommentRepository Comments => _commentRepository ?? new CommentRepository(_context);

        public IUserRoleRepository UserRoles => _userRoleRepository ?? new UserRoleRepository(_context);

        public IUserRepository Users => _userRepository ?? new UserRepository(_context);

    

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
