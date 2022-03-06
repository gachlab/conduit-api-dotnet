using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace Conduit.Articles
{
    public class EntityFrameworkRepository : Repository
    {
        private readonly Conduit.Sql.AppDbContext context;
        public EntityFrameworkRepository(Conduit.Sql.AppDbContext context)
        {
            this.context = context;
        }
        public override Task<IEnumerable<Article>> find()
        {
            return Task.FromResult<IEnumerable<Article>>(context.Articles.Select(this.mapToArticle).ToList());
        }

        public override async Task<Article> findOne(string id)
        {
            var dbArticle = await context.Articles.FindAsync(id);
            if (dbArticle != null)
            {
                return this.mapToArticle(dbArticle);
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
                var existingArticle = context.Articles.Where(dbArticle => dbArticle.slug == article.slug).Count();

                if (existingArticle == 0)
                {
                    var dbArticle = this.mapToDbArticle(article);
                    Console.WriteLine(dbArticle.slug);


                    context.Articles.Add(dbArticle);
                    try
                    {
                        context.SaveChanges();
                    }
                    catch (Exception e)
                    {
                        throw e;
                    }

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
                var existingArticle = context.Articles.Find(article.slug);
                if (existingArticle != null)
                {
                    context.Articles.Update(this.mapToDbArticle(article));
                    try
                    {
                        context.SaveChanges();
                    }
                    catch (Exception e)
                    {
                        throw e;
                    }

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

        public override Task deleteOne(string id)
        {
            var existingArticle = this.context.Articles.Find(id);
            if (existingArticle != null)
            {
                this.context.Articles.Remove(existingArticle);
                try
                {
                    context.SaveChanges();
                }
                catch (Exception e)
                {
                    throw e;
                }
                return Task.FromResult("");
            }
            else
            {
                throw new Exception("not-found");

            }

        }


        private Article mapToArticle(Conduit.Sql.Article dbArticle)
        {
            return new Article()
            {
                slug = dbArticle.slug,
                title = dbArticle.title,
                description = dbArticle.description,
                body = dbArticle.body,
                createdAt = dbArticle.createdAt,
                updatedAt = dbArticle.updatedAt,
                favorited = false,
                favoritesCount = 0,
                tagList = dbArticle.tagList != null ? dbArticle.tagList.Select(tag => tag.name != null ? tag.name : "").ToList() : new List<string>(),
                author = dbArticle.author != null ? new Author()
                {
                    username = dbArticle.author.username,
                    bio = dbArticle.author.bio,
                    image = dbArticle.author.image,
                    following = false
                } : new Author(),

            };
        }

        private Sql.Article mapToDbArticle(Article article)
        {
            return new Sql.Article()
            {
                slug = article.slug,
                title = article.title,
                description = article.description,
                body = article.body,
                tagList = article.tagList != null ? article.tagList.Select(tag => new Sql.Tag() { name = tag }).ToList() : new List<Sql.Tag>(),
                createdAt = article.createdAt,
                updatedAt = article.updatedAt,
                author = article.author != null ? new Sql.User()
                {
                    username = article.author.username
                } : new Sql.User() { }
            };
        }

    }
}