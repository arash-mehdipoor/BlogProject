using Blog.Domain.Articles;
using Blog.Infrastructure.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Infrastructure.Articles
{
    public class ArticleRepasitory : EfRepository<Article>, IArticleRepasitory
    {
        public ArticleRepasitory(BlogDatabaseContext dbContext) : base(dbContext)
        {
        }
    }
}
