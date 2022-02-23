using Blog.Domain.Articles.Entities;
using Blog.Domain.Articles.Repositories;
using Blog.Infrastructure.Common;
using System.Linq;

namespace Blog.Infrastructure.Articles.Services
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
