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
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(u => u.Mail).IsRequired();
            builder.Property(u => u.Mail).HasMaxLength(100);

            builder.Property(u => u.Name).IsRequired();
            builder.Property(u => u.Name).HasMaxLength(50);

            builder.Property(u => u.Surname).IsRequired();
            builder.Property(u => u.Surname).HasMaxLength(70);


            builder.HasOne<UserRole>(u => u.UserRole).WithMany(ur => ur.Users).HasForeignKey(u => u.UserRoleId);

            builder.HasData(new User
            {
                Id=1,
                CreatedBy=1,
                CreatedDate=DateTime.Now,
                Mail="test@gmail.com",
                Name="Test",
                Surname="Test",
                Password="TestTest",
                UserRoleId=1
            });
            
        }
    }
}
