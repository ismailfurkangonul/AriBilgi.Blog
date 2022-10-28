using AriBilgi.Blog.Shared.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AriBilgi.Blog.Entities.Concrete
{
    public class UserRole : EntityBase, IEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }

        public ICollection<User> Users { get; set; }
    }
}
