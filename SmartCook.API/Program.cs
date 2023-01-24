using MediatR;
using Microsoft.EntityFrameworkCore;
using SmartCook.Application.DBManipulation.Interfaces;
using SmartCook.Application.DBManipulation.Mapper;
using SmartCook.Application.DBManipulation.Services;
using SmartCook.Application.Mediator;
using SmartCook.Application.Spoonacular.Interfaces;
using SmartCook.Application.Spoonacular.Mapper;
using SmartCook.Application.Spoonacular.Services;
using SmartCook.Infrastructure.CloudinaryPhoto.Helpers;
using SmartCook.Infrastructure.DBManipulation.Data;
using SmartCook.Infrastructure.DBManipulation.Repositories;
using SmartCook.Infrastructure.Spoonacular.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddScoped<IRecipeService, RecipeService>();
builder.Services.AddScoped<IRecipeRepository, RecipeRepository>();

builder.Services.AddScoped<IDBRecipeService, DBRecipeService>();
builder.Services.AddScoped<IDBRecipeRepository, DBRecipeRepository>();

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddScoped<IPreferencesService, PreferencesService>();
builder.Services.AddScoped<IPreferencesRepository, PreferencesRepository>();

builder.Services.Configure<CloudinarySettings>(builder.Configuration.GetSection("CloudinarySettings"));
builder.Services.AddMediatR(typeof(SmartCookApplicationMediatREndpoint).Assembly);
builder.Services.AddAutoMapper(typeof(FromAnalyzedToDetailedRecipesProfile), typeof(DBRecipeProfile), typeof(UserProfile), typeof(PreferenceProfile));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDBContext>(
    o => o.UseNpgsql(builder.Configuration.GetConnectionString("SmartCookDb"))
);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
