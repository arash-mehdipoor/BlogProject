using AutoMapper;
using Blog.Domain.Articles;
using MediatR;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application.Articles.Queries.GetArticleList
{
    public class GetArticleListQuery : IRequest<IEnumerable<GetArticleListQuery>>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public string Image { get; set; }
        public bool Status { get; set; }
        public string UserName { get; set; }
    }

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
