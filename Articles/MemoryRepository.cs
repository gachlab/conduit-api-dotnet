namespace conduit_api_dotnet.Articles
{
    public class MemoryRepository : Repository
    {
        private readonly ICollection<Article> data;
        public MemoryRepository(ICollection<Article>? data)
        {
            this.data = data != null ? data : new List<Article>();
        }
        public override Task<IEnumerable<Article>> find()
        {
            return Task.FromResult<IEnumerable<Article>>(data);
        }
    }
}