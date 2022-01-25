using Blog.Domain.Common.Attributes;
using Blog.Domain.Common.Entities;
using Blog.Domain.Users.Entity;
using System;

namespace Blog.Domain.Articles.Entitiy
{
    [Audit]
    public class Article : Entity
    {
        public string Title { get; set; }
        public string Body { get; set; }
        public string Image { get; set; }
        public bool Status { get; set; }

        public string UserId { get; set; }
        public string UserName { get; set; }
        public User User { get; set; }
    }
}
