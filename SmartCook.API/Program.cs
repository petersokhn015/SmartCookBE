using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.OpenApi.Models;
using SmartCook.Application.DBManipulation.Interfaces;
using SmartCook.Application.DBManipulation.Mapper;
using SmartCook.Application.DBManipulation.Services;
using SmartCook.Application.Firebase.Interfaces;
using SmartCook.Application.Firebase.Services;
using SmartCook.Application.Mediator;
using SmartCook.Application.Spoonacular.Interfaces;
using SmartCook.Application.Spoonacular.Mapper;
using SmartCook.Application.Spoonacular.Services;
using SmartCook.Infrastructure.CloudinaryPhoto.Helpers;
using SmartCook.Infrastructure.CloudinaryPhoto.Interface;
using SmartCook.Infrastructure.CloudinaryPhoto.Service;
using SmartCook.Infrastructure.DBManipulation.Data;
using SmartCook.Infrastructure.DBManipulation.Repositories;
using SmartCook.Infrastructure.Firebase.Repository;
using SmartCook.Infrastructure.Spoonacular;
using SmartCook.Infrastructure.Spoonacular.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddHttpClient();

builder.Services.AddScoped<ICloudinaryPhotoService, CloudinaryPhotoService>();

builder.Services.AddScoped<IRecipeService, RecipeService>();
builder.Services.AddScoped<IRecipeRepository, RecipeRepository>();

builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();
builder.Services.AddScoped<IAuthenticationRepository, AuthenticationRepository>();

builder.Services.AddScoped<IDBRecipeService, DBRecipeService>();
builder.Services.AddScoped<IDBRecipeRepository, DBRecipeRepository>();

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddScoped<INutritionFactsService, NutritionFactsService>();
builder.Services.AddScoped<INutritionFactsRepository, NutritionFactsRepository>();

builder.Services.AddScoped<IPreferencesService, PreferencesService>();
builder.Services.AddScoped<IPreferencesRepository, PreferencesRepository>();

builder.Services.Configure<CloudinarySettings>(builder.Configuration.GetSection("CloudinarySettings"));

builder.Services.AddMediatR(typeof(SmartCookApplicationMediatREndpoint).Assembly);

builder.Services.AddAutoMapper(typeof(FromAnalyzedToDetailedRecipesProfile), 
    typeof(DBRecipeProfile), 
    typeof(UserProfile), 
    typeof(PreferenceProfile),
    typeof(SpoonacularPreferencesProfile));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddCors(opt =>
{
    opt.AddDefaultPolicy(builder =>
    {
        builder.AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod();
    });
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "SmartCook API", Version = "v1" });
});

builder.Services.AddDbContext<ApplicationDBContext>(
    o => o.UseNpgsql(builder.Configuration.GetConnectionString("SmartCookDb"))
);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "SmartCook API V1");
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors();

app.MapControllers();

app.Run();
