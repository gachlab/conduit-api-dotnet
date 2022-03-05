namespace Conduit.Articles
{
    public class Article
    {
        public string? slug { get; set; }
        public string? title { get; set; }
        public string? description { get; set; }
        public string? body { get; set; }
        public IList<string>? tagList { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime updatedAt { get; set; }
        public bool favorited { get; set; }
        public int favoritesCount { get; set; }
        public Author? author { get; set; }
    }

}
