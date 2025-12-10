using Hexagonal.Application.Case_Uso;
using Hexagonal.Application.Port_Primary;
using Hexagonal.Domain.interfaces;
using Hexagonal.Infraestructure.DBContext;
using Hexagonal.Infraestructure.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

//Inyeccion de dependencias
builder.Services.AddDbContext<ApplicationDbContext>(options=> options.UseSqlServer(connectionString));
builder.Services.AddTransient<IItemRepository,ItemRepository>();
builder.Services.AddTransient<IItemService,ItemService>();
//Fin inyeccion de dependencias

//Configurar swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//Fin Swagger

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.Run();


