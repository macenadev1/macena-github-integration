using System.Reflection;
using Macena.GitHub.Core.Settings;
using Macena.GitHub.DomainInterfaces;
using Macena.GitHub.Repositories;
using Macena.GitHub.WebApi.Settings;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Adicionar serviços ao contêiner
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(opt =>
{
    opt.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "Macena.GitHubApi", Version = "v1" });

    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    opt.IncludeXmlComments(xmlPath);
});

// Carregar as configurações do appsettings.json e outras fontes
builder.Configuration
    .SetBasePath(AppContext.BaseDirectory)
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddEnvironmentVariables();

// Registrar as configurações como um singleton
builder.Services.AddSingleton<IAppSettings, AppSettings>(sp =>
{
    var configuration = sp.GetRequiredService<IConfiguration>();
    return new AppSettings(configuration);
});

// Configurar a conexão com o banco de dados
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<RepositoryContext>(options =>
    options.UseSqlServer(connectionString, b => b.MigrationsAssembly("Macena.GitHub.Repositories")));

// Registrar repositório e suas dependências
builder.Services.AddScoped<IRepository, Repository>();

var app = builder.Build();

// Configurar o pipeline de solicitação HTTP
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
