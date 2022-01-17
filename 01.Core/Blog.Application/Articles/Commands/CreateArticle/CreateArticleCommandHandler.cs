using AutoMapper;
using Blog.Domain.Articles;
using Blog.Domain.Users;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;

namespace Blog.Application.Articles.Commands.CreateArticle
{


    public class CreateArticleCommandHandler : RequestHandler<CreateArticleCommand, int>
    {
        private readonly IArticleRepasitory _article;
        private readonly IMapper _mapper;

        public CreateArticleCommandHandler(IArticleRepasitory article, IMapper mapper)
        {
            _article = article;
            _mapper = mapper;
        }

        protected override int Handle(CreateArticleCommand request)
        {
            var article = _mapper.Map<Article>(request);
            _article.Add(article);
            return article.Id;
        }
    }
}
