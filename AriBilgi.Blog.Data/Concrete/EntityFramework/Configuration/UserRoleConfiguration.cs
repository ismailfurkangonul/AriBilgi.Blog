using AriBilgi.Blog.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AriBilgi.Blog.Data.Concrete.EntityFramework.Configuration
{
    public class UserRoleConfiguration : IEntityTypeConfiguration<UserRole>
    {
        public void Configure(EntityTypeBuilder<UserRole> builder)
        {
            builder.Property(r => r.Title).IsRequired();
            builder.Property(r => r.Title).HasMaxLength(30);

            builder.Property(r => r.Description).IsRequired();
            builder.Property(r => r.Description).HasMaxLength(250);

            builder.HasData(new UserRole
            {
                Id = 1,
                CreatedBy=1,
                CreatedDate=DateTime.Now,
                Description="Test Rolü Açıklaması",
                Title="Test Rolü"
            });
        }
    }
}
