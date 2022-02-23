using AutoMapper;
using Blog.Application.Articles.Commands.EditArticle;
using Blog.Domain.Articles.QueryResults;
using Blog.Domain.Articles.Repositories;
using MediatR;

namespace Blog.Application.Articles.Queries.GetArticleById
{
    public class FindArticleQueryHandler : RequestHandler<FindArticleQuery, EditArticleQr>
    {
        private readonly IArticleRepasitory _articleRepasitory;
        private readonly IMapper _mapper;
        public FindArticleQueryHandler(IArticleRepasitory articleRepasitory, IMapper mapper)
        {
            _articleRepasitory = articleRepasitory;
            _mapper = mapper;
        }

        protected override EditArticleQr Handle(FindArticleQuery request)
        {
            var article = _articleRepasitory.Get(request.Id);
            var res = _mapper.Map<EditArticleQr>(article);
            return res;
        }
    }
}
