namespace conduit_api_dotnet.Articles
{
    public abstract class Repository
    {
        public abstract Task<IEnumerable<Article>> find();
        public abstract Task<Article> findOne(string id);
        public abstract Task<string> insertOne(Article article);

    }
}