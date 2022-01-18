using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application.Articles.Commands.EditArticle
{
    public class EditArticleCommand : IRequest<int>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public string Image { get; set; }
        public bool Status { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }
    }
}
