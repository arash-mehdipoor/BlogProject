using AutoMapper;
using Blog.Application.Users.Commands.RegisterUser;
using Blog.Domain.Users.Entities;

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
