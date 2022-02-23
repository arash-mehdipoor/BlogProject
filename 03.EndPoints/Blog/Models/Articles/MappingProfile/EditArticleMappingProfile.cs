using AutoMapper;
using Blog.Application.Articles.Commands.EditArticle;
using Blog.Application.Articles.Queries.GetArticleList;
using Blog.Domain.Articles.Entities;
using Blog.Domain.Articles.QueryResults;

namespace Blog.Models.Articles.MappingProfile
{
    public class EditArticleMappingProfile : Profile
    {
        public EditArticleMappingProfile()
        {
            CreateMap<Article, EditArticleQr>().ReverseMap();
            CreateMap<Article, GetArticleListQuery>().ReverseMap();
        }
    }
}
