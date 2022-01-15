using Blog.Domain.Common.Attributes;
using Blog.Domain.Common.Entities;
using Blog.Domain.Users;

namespace Blog.Domain.Articles
{
    [Audit]
    public class Article: Entity
    {
        public string Title { get; set; }
        public string Body { get; set; }
        public string Image { get; set; }
        public bool Status { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
    }
}
