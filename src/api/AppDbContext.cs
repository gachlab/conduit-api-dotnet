using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;


namespace Conduit.Sql
{
    public class AppDbContext : DbContext
    {
        public DbSet<Article> Articles => Set<Article>();
        public DbSet<Tag> Tags => Set<Tag>();

        public DbSet<User> Users => Set<User>();

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { }
    }

    public class DbContextSqlLiteFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            var options = new DbContextOptionsBuilder<AppDbContext>();
            options.UseSqlite("Data Source=conduit.db");

            return new AppDbContext(options.Options);
        }
    }

    public class Article
    {
        [Key]
        public string slug { get; set; }
        public string title { get; set; }
        public string? description { get; set; }
        public string? body { get; set; }
        public ICollection<Tag>? tagList { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime updatedAt { get; set; }
        public User author { get; set; }
    }


    public class User
    {

        [Key]

        public string username { get; set; }
        public string password { get; set; }
        public string email { get; set; }

        public string? token { get; set; }

        public string? bio { get; set; }
        public string? image { get; set; }
    }

    public class Tag
    {
        [Key]
        public string name { get; set; }
        public ICollection<Article> articles { get; set; }
    }
}