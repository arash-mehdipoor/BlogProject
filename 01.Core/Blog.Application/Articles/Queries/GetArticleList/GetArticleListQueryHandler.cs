using AutoMapper;
using Blog.Domain.Articles.Repositories;
using MediatR;
using System.Collections.Generic;

namespace Blog.Application.Articles.Queries.GetArticleList
{
    public class GetArticleListQueryHandler : RequestHandler<GetArticleListQuery, IEnumerable<GetArticleListQuery>>
    {
        private readonly IArticleRepasitory _articleRepasitory;
        private readonly IMapper _mapper;
        public GetArticleListQueryHandler(IArticleRepasitory articleRepasitory, IMapper mapper)
        {
            _articleRepasitory = articleRepasitory;
            _mapper = mapper;
        }

        protected override IEnumerable<GetArticleListQuery> Handle(GetArticleListQuery request)
        {
            var articles = _articleRepasitory.GetAll();
            var articleDto = _mapper.Map<IEnumerable<GetArticleListQuery>>(articles);
            return articleDto;
        }
    }
}
