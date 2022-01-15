using Blog.Domain.Articles;
using MediatR;
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
                Image = request.Image
            };
            _article.Add(article);
            return article.Id;
        }
    }
}
