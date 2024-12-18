using Microsoft.IdentityModel.Tokens;
using Molong.API.Mappers;
using Molong.HostApp.Services;
using Newtonsoft.Json;
using OpenIddict.Validation.AspNetCore;
using Polly;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration;
var services = builder.Services;

// Add services to the container.

services
    .AddControllers()
    .AddNewtonsoftJson(options =>
    {
        options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
    });

services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyHeader()
               .AllowAnyMethod();
    });
});


services.AddDbContext<MolongDbContext>(options =>
{
    options.EnableSensitiveDataLogging(true);
    //options.UseSqlServer(configuration.GetConnectionString("MolongDbConnection")!, b => b.MigrationsAssembly("Molong.API"));
    options.UseNpgsql(configuration.GetConnectionString("MolongDbConnection")!, b => b.MigrationsAssembly("Molong.API"));
});

services.Scan(
    scan => scan
    .FromAssemblyOf<ArticleService>()
    .AddClasses(classes => classes.Where(
        t => t.Name.EndsWith("Service", StringComparison.Ordinal)))
    .AsSelf()
    .WithScopedLifetime());

services.AddAutoMapper(typeof(DtoToDomainProfile));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
services.AddEndpointsApiExplorer();
services.ConfigureSwaggerGen(options =>
{
    options.CustomSchemaIds(x => x.FullName);
});
services.AddSwaggerGen();

services.AddOpenIddict()
    .AddValidation(options =>
    {
        options.SetIssuer(configuration["OpenIddict:IssuerUrl"]!);

        options.AddEncryptionKey(new SymmetricSecurityKey(
            Convert.FromBase64String(configuration["OpenIddict:SecurityKey"]!)));

        options.UseSystemNetHttp();

        options.UseAspNetCore();
    });

services.AddAuthentication(OpenIddictValidationAspNetCoreDefaults.AuthenticationScheme);
services.AddAuthorization(options =>
{
    options.AddPolicy("ApiScope", policy =>
    {

        policy.RequireAssertion(context =>
        {
            var httpContext = context.Resource as HttpContext ?? throw new NullReferenceException("context.Resource is null");
            return context.User.IsInRole("admin") || httpContext.Request.Method == "GET";
        });

        policy.RequireAuthenticatedUser();

    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.UseCors();

app.MapGet("/test", (IConfiguration configuration) =>
{
    return $"{Assembly.GetExecutingAssembly().FullName};��ǰʱ�䣺{DateTime.Now}";
});

app.MapControllers()
    .RequireAuthorization("ApiScope");


app.Run();