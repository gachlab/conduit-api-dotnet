namespace conduit_api_dotnet.Articles
{
    public abstract class UseCases
    {
        public abstract Task<IEnumerable<Article>> list();
    }
}