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

        public CreateArticleCommandHandler(IArticleRepasitory article)
        {
            _article = article;
        }

        protected override int Handle(CreateArticleCommand request)
        {
            var article = new Article()
            {
                Title = request.Title,
                Body = request.Body,
                Status = request.Status,
                Image = request.Image,
                UserId = request.UserId
            };
            _article.Add(article);
            return article.Id;
        }
    }
}
