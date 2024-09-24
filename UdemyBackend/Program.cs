using FluentValidation;
using Microsoft.EntityFrameworkCore;
using UdemyBackend.DTOs;
using UdemyBackend.Models;
using UdemyBackend.Repository;
using UdemyBackend.Services;
using UdemyBackend.Validators;

var builder = WebApplication.CreateBuilder(args);

// Inyección de dependencia de la interface con su implementación para usarla en los controllers
// builder.Services.AddSingleton<IPeopleService, PeopleService>();

// Nueva forma de inyección mediante key (.NET 8+)
builder.Services.AddKeyedSingleton<IPeopleService, PeopleService>("peopleService");
builder.Services.AddKeyedSingleton<IRandomService, RandomService>("randomSingleton");
builder.Services.AddKeyedScoped<IRandomService, RandomService>("randomScoped");
builder.Services.AddKeyedTransient<IRandomService, RandomService>("randomTransient");
builder.Services.AddKeyedScoped<ICommonService<BeerDto, BeerInsertDto, BeerUpdateDto>, BeerService>("beerService");

// Patrón de diseño Factory (en este caso crear objetos tipo HttpClient con una 
// configuración inicial, para luego inyectarlo en nuestros servicios o controladores
builder.Services.AddScoped<IPostsService, PostsService>();
builder.Services.AddHttpClient<IPostsService, PostsService>(client =>
{
    // Leyendo la url desde el archivo appsettings.json
    // El ! es para indicar que el valor en este punto no es nulo
    client.BaseAddress = new Uri(builder.Configuration["BaseUrlPosts"]!);
});

// Inyención de la base de datos
builder.Services.AddDbContext<StoreContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("StoreConnection"));
});

// Validaciones con FluentValidator
builder.Services.AddScoped<IValidator<BeerInsertDto>, BeerInsertValidator>();
builder.Services.AddScoped<IValidator<BeerUpdateDto>, BeerUpdateValidator>();

// Repository
builder.Services.AddScoped<IRepository<Beer>, BeerRepository>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
