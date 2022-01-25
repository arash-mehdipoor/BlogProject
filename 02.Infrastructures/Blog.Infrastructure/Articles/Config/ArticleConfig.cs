using Blog.Domain.Articles.Entitiy;
using Blog.Domain.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Infrastructure.Articles.Config
{
    public class ArticleConfig : IEntityTypeConfiguration<Article>
    {
        public void Configure(EntityTypeBuilder<Article> builder)
        {
            builder.Property(a => a.Title).HasMaxLength(150).IsRequired();
            builder.Property(a => a.Body).IsRequired();

            builder.HasOne(u => u.User).WithMany().HasForeignKey(u => u.UserId);
        }
    }
}
