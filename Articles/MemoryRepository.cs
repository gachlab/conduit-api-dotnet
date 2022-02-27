using System.Runtime.Serialization;

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

        public override Task<Article> findOne(string id)
        {
            var articleInRepo = data.FirstOrDefault(article => article.slug == id);
            if (articleInRepo != null)
            {
                return Task.FromResult<Article>(articleInRepo);
            }
            else
            {
                throw new Exception("not-found");
            }
        }

        public override Task<string> insertOne(Article article)
        {
            if (article.slug != null)
            {
                var articleInRepo = data.FirstOrDefault(articleInRepo => articleInRepo.slug == article.slug);
                if (articleInRepo == null)
                {
                    data.Add(article);
                    return Task.FromResult<string>(article.slug);
                }
                else
                {
                    throw new Exception("conflict");
                }
            }
            else
            {
                throw new Exception("bad-request");
            }

        }
    }
}