using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;


namespace Conduit.Articles.Sql
{
    public class DbContextSqlLite : DbContext
    {
        public DbSet<Article> Articles => Set<Article>();
        public DbSet<Tag> Tags => Set<Tag>();

        public DbContextSqlLite(DbContextOptions<DbContextSqlLite> options) : base(options)
        { }
    }

    public class DbContextSqlLiteFactory : IDesignTimeDbContextFactory<DbContextSqlLite>
    {
        public DbContextSqlLite CreateDbContext(string[] args)
        {
            var options = new DbContextOptionsBuilder<DbContextSqlLite>();
            options.UseSqlite("Data Source=conduit.db");

            return new DbContextSqlLite(options.Options);
        }
    }

    public class Article
    {
        [Key]
        public string? slug { get; set; }
        public string? title { get; set; }
        public string? description { get; set; }
        public string? body { get; set; }
        public ICollection<Tag>? tagList { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime updatedAt { get; set; }
        public bool favorited { get; set; }
        public int favoritesCount { get; set; }
        public Author? author { get; set; }
    }


    public class Author
    {

        [Key]

        public string? username { get; set; }
        public string? bio { get; set; }
        public string? image { get; set; }
        public bool following { get; set; }
    }

    public class Tag
    {
        [Key]
        public string? name { get; set; }

    }
}