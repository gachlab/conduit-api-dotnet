using System.Text.Json;
using dotenv.net;
using Microsoft.EntityFrameworkCore;
using GenFu;

DotEnv.Load();

var envVars = DotEnv.Read();

// Conduit.Articles.MemoryRepository ArticlesRepository;

// Conduit.Tags.MemoryRepository TagsRepository;

// configureMemoryRepository(envVars, out ArticlesRepository, out TagsRepository);


// Add services to the container.

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<Conduit.Sql.AppDbContext>(options =>
{
    options.UseSqlite("Data Source=conduit.db");
});


builder.Services.AddScoped<Conduit.Articles.Repository, Conduit.Articles.EntityFrameworkRepository>();
builder.Services.AddScoped<Conduit.Articles.UseCases, Conduit.Articles.UseCasesStandard>();
builder.Services.AddScoped<Conduit.Users.Repository, Conduit.Users.EntityFrameworkRepository>();
builder.Services.AddScoped<Conduit.Users.UseCases, Conduit.Users.UseCasesStandard>();
// builder.Services.AddSingleton<Conduit.Tags.Repository>((provider) => TagsRepository);
// builder.Services.AddSingleton<Conduit.Tags.UseCases, Conduit.Tags.UseCasesStandard>();

builder.Services.AddControllers();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

//app.UseAuthorization();

app.MapControllers();


app.Run();

// static void configureMemoryRepository(IDictionary<string, string> envVars, out Conduit.Articles.MemoryRepository ArticlesRepository, out Conduit.Tags.MemoryRepository TagsRepository)
// {
//     var ArticlesJsonString = envVars["CONDUIT_ARTICLES_DATA_JSON"];
//     var tagsJsonString = envVars["CONDUIT_TAGS_DATA_JSON"];


//     var ArticlesData = JsonSerializer.Deserialize<List<Conduit.Articles.Article>>(ArticlesJsonString);
//     ArticlesRepository = new Conduit.Articles.MemoryRepository(ArticlesData.ToDictionary(m => m.slug, m => m));

//     var tagsData = JsonSerializer.Deserialize<ICollection<string>>(tagsJsonString).Select(tag => new Conduit.Tags.Tag() { name = tag.ToString() }).ToList();
//     TagsRepository = new Conduit.Tags.MemoryRepository(tagsData);
// }