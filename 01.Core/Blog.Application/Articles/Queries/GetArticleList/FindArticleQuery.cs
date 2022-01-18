using AutoMapper;
using Blog.Application.Articles.Commands.EditArticle;
using Blog.Domain.Articles;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application.Articles.Queries.GetArticleList
{
    public class FindArticleQuery : IRequest<EditArticleCommand>
    {
        public int Id { get; set; }
    }
    public class FindArticleQueryHandler : RequestHandler<FindArticleQuery, EditArticleCommand>
    {
        private readonly IArticleRepasitory _articleRepasitory;
        private readonly IMapper _mapper;
        public FindArticleQueryHandler(IArticleRepasitory articleRepasitory, IMapper mapper)
        {
            _articleRepasitory = articleRepasitory;
            _mapper = mapper;
        }

        protected override EditArticleCommand Handle(FindArticleQuery request)
        {
            var article = _articleRepasitory.Get(request.Id);
            var res = _mapper.Map<EditArticleCommand>(article);
            return res;
        }
    }
}
