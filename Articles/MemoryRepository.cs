using System.Runtime.Serialization;

namespace conduit_api_dotnet.Articles
{
    public class MemoryRepository : Repository
    {
        private readonly IDictionary<string, Article> data;
        public MemoryRepository(IDictionary<string, Article> data)
        {
            this.data = data != null ? data : new Dictionary<string, Article>();
        }
        public override Task<IEnumerable<Article>> find() =>
         Task.FromResult<IEnumerable<Article>>(data.Select((key) => key.Value));


        public override Task<Article> findOne(string id)
        {
            var articleInRepo = data.FirstOrDefault(article => article.Key == id);
            if (articleInRepo.Value != null)
            {
                return Task.FromResult<Article>(articleInRepo.Value);
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
                var articleInRepo = data.FirstOrDefault(articleInRepo => articleInRepo.Key == article.slug);
                if (articleInRepo.Value == null)
                {
                    data.Add(article.slug, article);
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

        public override Task updateOne(Article article)
        {
            if (article.slug != null)
            {
                var articleInRepo = data.FirstOrDefault(articleInRepo => articleInRepo.Key == article.slug);
                if (articleInRepo.Value != null)
                {
                    data.Remove(article.slug);
                    data.Add(article.slug, article);
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

        internal override Task deleteOne(string id)
        {
            if (data.Remove(id))
            {
                return Task.FromResult<string>("");
            }
            else
            {
                throw new Exception("not-found");
            }
        }
    }
}
