using Blog.Domain.Articles.QueryResults;
using MediatR;

namespace Blog.Application.Articles.Queries.GetArticleById
{
    public class FindArticleQuery : IRequest<EditArticleQr>
    {
        public int Id { get; set; }
    }
}
