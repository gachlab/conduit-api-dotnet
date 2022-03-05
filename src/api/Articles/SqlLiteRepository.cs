using Microsoft.EntityFrameworkCore;

namespace Conduit.Articles
{
    public class EntityFrameworkRepository : Repository
    {
        private readonly Conduit.Articles.Sql.DbContextSqlLite context;
        public EntityFrameworkRepository(Conduit.Articles.Sql.DbContextSqlLite context)
        {
            this.context = context;
        }
        public override Task<IEnumerable<Article>> find()
        {
            return Task.FromResult<IEnumerable<Article>>(this.context.Articles.Select(dbArticle => new Article()
            {
                slug = dbArticle.slug
            }).ToList());
        }

        public override Task<Article> findOne(string id)
        {
            throw new NotImplementedException();
        }

        public override Task<string> insertOne(Article article)
        {
            throw new NotImplementedException();
        }

        public override Task updateOne(Article article)
        {
            throw new NotImplementedException();
        }

        internal override Task deleteOne(string id)
        {
            throw new NotImplementedException();
        }

    }
}