using Blog.Domain.Articles.Constants;

namespace Blog.Domain.Articles.QueryResults
{
    public class EditArticleQr
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public string Image { get; set; }
        public ArticleStatus Status { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }
    }
}
