namespace conduit_api_dotnet.Articles
{
    public abstract class UseCases
    {
        public abstract Task<IEnumerable<Article>> list();
        public abstract Task<Article> details(string id);

        public abstract Task<string> create(Article article);

    }
}