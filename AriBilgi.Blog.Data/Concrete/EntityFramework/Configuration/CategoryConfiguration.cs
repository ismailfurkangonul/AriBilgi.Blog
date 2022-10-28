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
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.Property(c => c.Title).IsRequired();
            builder.Property(c => c.Title).HasMaxLength(70);

            builder.Property(c => c.Content).HasMaxLength(500);

            builder.HasData(new Category
            {
                Id=1,
                Title="Test Kategori",
                Content="Test Kategori İçerik",
                CreatedBy=1,
                CreatedDate=DateTime.Now
            });
        }
    }
}
