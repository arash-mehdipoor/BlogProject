using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application.Articles.Commands.CreateArticle
{
    public class CreateArticleCommand : IRequest<int>
    {
        public string Title { get; set; }
        public string Body { get; set; }
        public string Image { get; set; }
        public bool Status { get; set; }
        public string UserId { get; set; }
    }
}
