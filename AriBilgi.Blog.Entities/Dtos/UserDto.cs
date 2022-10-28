using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AriBilgi.Blog.Entities.Dtos
{
    public class UserDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Mail { get; set; }
        public int UserRoleId { get; set; }

        public UserRoleDto UserRole { get; set; }
        public ICollection<ArticleDto> Articles { get; set; }
     
    }
}
