using Blog.Domain.Articles;
using Blog.Infrastructure.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Infrastructure.Articles
{
    public class UserRepasitory : EfRepository<Article>, IArticleRepasitory
    {
        public UserRepasitory(BlogDatabaseContext dbContext) : base(dbContext)
        {
        }
    }
}
