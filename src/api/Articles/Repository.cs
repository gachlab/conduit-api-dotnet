namespace Conduit.Articles
{
    public abstract class Repository
    {
        public abstract Task<IEnumerable<Article>> find();
        public abstract Task<Article> findOne(string id);
        public abstract Task<string> insertOne(Article article);
        public abstract Task updateOne(Article article);
        internal abstract Task deleteOne(string id);
    }
}