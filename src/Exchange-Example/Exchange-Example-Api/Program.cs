using Exchange_Example_Api.Configuration;
using Exchange_Example_Api.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var config = builder.Configuration;

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(config.GetConnectionString("Default")));

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.Authority = config["Auth:Authority"];
        options.Audience = config["Auth:Audience"]; // maps to clientId
        options.RequireHttpsMetadata = false; // dev only
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateAudience = true,
            ValidateIssuer = true,
            ValidateLifetime = true,
        };
    });

builder.Services.AddAuthorizationBuilder()
    .AddPolicy("RequireUser", policy => policy.RequireClaim(ClaimTypes.Role, "api.user", "api.admin"))
    .AddPolicy("RequireAdmin", policy => policy.RequireClaim(ClaimTypes.Role, "api.admin"));

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngularApp",
        policy => policy
            .WithOrigins("http://localhost:4200")
            .AllowAnyHeader()
            .AllowAnyMethod()
    );
});

builder.Services.ConfigureServices();
builder.Services.AddRequestHandlers();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

ApDbContextConfiguration.RunMigrationsOnStartup(app);

if (app.Environment.IsDevelopment())
{
    ApDbContextConfiguration.SeedDatabase(app);
}

app.UseHttpsRedirection();

app.UseCors("AllowAngularApp");

app.UseAuthentication();
app.UseAuthorization();

CustomEndpointConfiguration.MapAllCustomEndpoints(app);

app.Run();
