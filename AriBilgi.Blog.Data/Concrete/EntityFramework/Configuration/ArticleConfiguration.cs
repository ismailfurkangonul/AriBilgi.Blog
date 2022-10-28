using AriBilgi.Blog.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace AriBilgi.Blog.Data.Concrete.EntityFramework.Configuration
{
    public class ArticleConfiguration : IEntityTypeConfiguration<Article>
    {
        public void Configure(EntityTypeBuilder<Article> builder)
        {
            builder.Property(a => a.Title).HasMaxLength(100);
            builder.Property(a => a.Title).IsRequired();

            builder.Property(a => a.Content).IsRequired();
            builder.Property(a => a.Content).HasColumnType("nvarchar(max)");


            builder.HasOne<Category>(a => a.Category).WithMany(c => c.Articles).HasForeignKey(a => a.CategoryId);
            builder.HasOne<User>(a => a.User).WithMany(u => u.Articles).HasForeignKey(a => a.UserId);

            builder.HasData(new Article { 
                Id=1,
                CategoryId=1,
                Title="TEST DATA",
                Content="TEST DATA İÇERİK",
                CreatedBy=1,
                CreatedDate=DateTime.Now,
                UserId=1
            });


        }
    }
}
