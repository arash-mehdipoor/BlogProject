using AutoMapper;
using Blog.Domain.Articles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application.Articles.Commands.CreateArticle
{
    public class CreateArticleMappingProfile : Profile
    {
        public CreateArticleMappingProfile()
        {
            CreateMap<Article, CreateArticleCommand>().ReverseMap();
        }
    }
}
