using System.Text.Json;
using dotenv.net;


DotEnv.Load();

var envVars = DotEnv.Read();

var ArticlesJsonString = envVars["CONDUIT_ARTICLES_DATA_JSON"];
var tagsJsonString = envVars["CONDUIT_TAGS_DATA_JSON"];


var ArticlesData = JsonSerializer.Deserialize<ICollection<conduit_api_dotnet.Articles.Article>>(ArticlesJsonString);
var ArticlesRepository = new conduit_api_dotnet.Articles.MemoryRepository(ArticlesData);


var tagsData = JsonSerializer.Deserialize<ICollection<string>>(tagsJsonString).Select(tag => new conduit_api_dotnet.Tags.Tag() { name = tag.ToString() }).ToList();
var TagsRepository = new conduit_api_dotnet.Tags.MemoryRepository(tagsData);


// Add services to the container.

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddSingleton<conduit_api_dotnet.Articles.Repository>((services) => ArticlesRepository);
builder.Services.AddSingleton<conduit_api_dotnet.Articles.UseCases>((services) => new conduit_api_dotnet.Articles.UseCasesStandard(ArticlesRepository));
builder.Services.AddSingleton<conduit_api_dotnet.Tags.Repository>((services) => TagsRepository);
builder.Services.AddSingleton<conduit_api_dotnet.Tags.UseCases>((services) => new conduit_api_dotnet.Tags.UseCasesStandard(TagsRepository));
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
