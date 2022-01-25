using AutoMapper;
using Blog.Application.Users.Commands.RegisterUser;
using Blog.Domain.Articles;
using Blog.Domain.Users.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Infrastructure.Users.Mapping
{
    public class RegisterUserMappingProfile : Profile
    {
        public RegisterUserMappingProfile()
        {
            CreateMap<User, RegisterUserCommand>().ReverseMap();
        }
    }
}
