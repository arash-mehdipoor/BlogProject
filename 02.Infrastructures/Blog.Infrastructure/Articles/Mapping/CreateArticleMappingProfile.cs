using AutoMapper;
using Blog.Application.Articles.Commands.CreateArticle;
using Blog.Domain.Articles.Entitiy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
