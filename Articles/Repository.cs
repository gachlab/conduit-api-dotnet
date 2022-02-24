namespace conduit_api_dotnet.Articles
{
    public abstract class Repository
    {
        public abstract Task<IEnumerable<Article>> find();

    }
}