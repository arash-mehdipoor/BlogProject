using AutoMapper;
using Blog.Application.Articles.Queries.GetArticleList;
using Blog.Domain.Articles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application.Articles.Commands.EditArticle
{
    public class EditArticleMappingProfile : Profile
    {
        public EditArticleMappingProfile()
        {
            CreateMap<Article, EditArticleCommand>().ReverseMap();
            CreateMap<Article, GetArticleListQuery>().ReverseMap();
        }
    }
}
