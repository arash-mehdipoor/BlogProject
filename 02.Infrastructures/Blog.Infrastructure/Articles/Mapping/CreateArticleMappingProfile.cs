using AutoMapper;
using Blog.Application.Articles.Commands.CreateArticle;
using Blog.Domain.Articles.Entities;

namespace Blog.Infrastructure.Articles.Mapping
{
    public class CreateArticleMappingProfile : Profile
    {
        public CreateArticleMappingProfile()
        {
            CreateMap<Article, CreateArticleCommand>().ReverseMap();
        }
    }
}
