using Blog.Domain.Articles.Entitiy;
using Blog.Domain.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Domain.Articles.Interfaces
{
    public interface IArticleRepasitory : IRepasitory<Article>
    {
        int GetArticleCountByUserId(string userId);
    }
}
