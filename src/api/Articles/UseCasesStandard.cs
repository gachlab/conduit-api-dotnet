namespace Conduit.Articles
{
    public partial class UseCasesStandard : UseCases
    {
        private readonly Repository articles;
        public UseCasesStandard(Repository articles)
        {
            this.articles = articles;
        }

        public override Task<IEnumerable<Article>> list()
        {
            return articles.find();
        }

        public override Task<Article> details(string id)
        {
            return articles.findOne(id);
        }

        public override Task<Article> create(Article article)
        {
            if (article.title != null && article.title != "")
            {
                try
                {
                    article.slug = article.title.Replace(" ", "-").ToLower();

                    var insertionDate = new DateTime();
                    article.createdAt = insertionDate;
                    article.updatedAt = insertionDate;
                    articles.insertOne(article);
                    return Task.FromResult<Article>(article);
                }
                catch (Exception e)
                {
                    throw e;
                }

            }
            else
            {
                throw new Exception("bad-request");
            }

        }

        public override Task<Article> update(Article article)
        {
            try
            {
                articles.updateOne(article);
                return Task.FromResult<Article>(article);
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        internal override Task remove(string id)
        {
            try
            {
                return articles.deleteOne(id);

            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}