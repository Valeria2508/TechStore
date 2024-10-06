using System.Text;
using DotNetEnv;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using TechStore.Config;
using TechStore.Data;
using TechStore.Repositories;
using TechStore.Services;

var builder = WebApplication.CreateBuilder(args);

Env.Load();

var db_host = Environment.GetEnvironmentVariable("DB_HOST");
var db_port = Environment.GetEnvironmentVariable("DB_PORT");
var db_database = Environment.GetEnvironmentVariable("DB_DATABASE");
var db_username = Environment.GetEnvironmentVariable("DB_USERNAME");
var db_password = Environment.GetEnvironmentVariable("DB_PASSWORD");

var conectionDb = $"server={db_host};port={db_port};database={db_database};uid={db_username};password={db_password}";

builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseMySql(conectionDb, ServerVersion.Parse("8.0.20-mysql")));

builder.Services.AddSingleton<Utilities>(); //add singleton sirve para poder usar las utilidades

builder.Services.AddScoped<IProductRepository, ProductSerice>();

//JWT configuracion
builder.Services.AddAuthentication(config =>
{
    config.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    config.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    config.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(config =>
{
    config.RequireHttpsMetadata = false;
    config.SaveToken = true;
    config.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidIssuer = Environment.GetEnvironmentVariable("JWT_ISSUER"),
        ValidateAudience = false, // false because the audience is public
        ValidAudience = Environment.GetEnvironmentVariable("JWT_AUDIENCE"),
        ValidateLifetime = true,
        ClockSkew = TimeSpan.Zero,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Environment.GetEnvironmentVariable("JWT_KEY")!))
    };
});



// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

//el candadito del swagger

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "TechStore API", Version = "v1" });

    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "JWT Authorization header using the Bearer scheme. Example: \"Bearer {token}\"",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] {}
        }
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

app.UseAuthorization();

// welcome page

app.Use(async (context, next) =>
{
    if (context.Request.Path == "/")
    {
        var htmlContent = @"
        <html>
            <head>
                <title>TechStore API</title>
            </head>
            <body style='font-family: Arial, sans-serif; background-color: #f4f4f4; text-align: center; height: 90%; display: flex; flex-direction: column; justify-content: center; align-items: center;'>
                <h1 style='color: #333; font-size: 36px;'>Welcome to TechStore API</h1>
                <a href='/swagger' style='color: #007bff; text-decoration: none;'> Click here to Swagger documentation</a>
            </body>
        </html>";

        context.Response.ContentType = "text/html";
        await context.Response.WriteAsync(htmlContent);
    }
    else
    {
        await next();
    }
});

// fin de wolcome pages

app.MapControllers();

app.Run();
