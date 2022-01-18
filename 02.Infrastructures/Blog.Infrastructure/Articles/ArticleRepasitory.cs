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
        private readonly BlogDatabaseContext _dbContext;
        public ArticleRepasitory(BlogDatabaseContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public int GetArticleCountByUserId(string userId)
        {
            return _dbContext.Articles.Where(a => a.UserId == userId).Count();
        }
    }
}
