namespace Conduit.Articles
{
    public abstract class UseCases
    {
        public abstract Task<IEnumerable<Article>> list();
        public abstract Task<Article> details(string id);

        public abstract Task<Article> create(Article article);
        public abstract Task<Article> update(Article article);
        internal abstract Task remove(string id);
    }
}