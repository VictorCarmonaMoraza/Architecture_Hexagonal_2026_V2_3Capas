using API.Extensions;
using Hexagonal.Application.Case_Uso;
using Hexagonal.Application.Case_Uso_Genericos;
using Hexagonal.Application.Genericos;
using Hexagonal.Application.Port_Primary;
using Hexagonal.Domain.Entities;
using Hexagonal.Domain.GenericosDomain;
using Hexagonal.Domain.interfaces;
using Hexagonal.Infraestructure.DBContext;
using Hexagonal.Infraestructure.GenericosInfraestructure;
using Hexagonal.Infraestructure.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

//Inyeccion de dependencias
//builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));
//builder.Services.AddTransient<IItemRepository, ItemRepository>();
//builder.Services.AddTransient<IItemService, ItemService>();
//builder.Services.AddTransient<ICommonRepository<Nota>, NoteRepository>();
//builder.Services.AddTransient<ICommonService<Nota>, NotaService>();
//Fin inyeccion de dependencias

// Llamada a la extensión externa
builder.Services.AddProjectServices(connectionString);

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

app.MapGet("/items", async (IItemService itemService) =>
{
    var items = await itemService.GetAllItemsAsync();
    return Results.Ok(items);
}).WithName("GetItems");
app.MapPut("/items/{id}", async (int id, IItemService itemService) =>
{
    await itemService.UpdateItemById(id);
}).WithName("UpdateItems");
app.MapPost("/items", async (string title, IItemService itemService) =>
{
    await itemService.AddItemAsync(title);
    return Results.Ok("Item agregado correctamente");
}).WithName("CreateItem");

app.MapGet("/notes", async (ICommonService<Nota> notaService) =>
{
    var notas = await notaService.GetAllItemsAsync();
    return Results.Ok(notas);
}).WithName("GetNotas");
app.MapPost("/notes", async (Nota nota,ICommonService<Nota> notaService) =>
{
    await notaService.AddItemAsync(nota);
    return Results.Created();
}).WithName("CreateNota");
app.MapPut("/notes/{id}", async (int id, string newmessage, ICommonService<Nota> notaService) =>
{
    // 1) Buscar nota por ID de forma eficiente
    var existingNote = await notaService.GetByIdAsync(id);

    if (existingNote is null)
        return Results.NotFound($"La nota con id {id} no existe");

    // 2) Preparar actualización
    existingNote.UpdateMessage(newmessage);

    // 3) Guardar cambios
    bool updated = await notaService.UpdateItemById(existingNote);

    return updated
        ? Results.Ok("Nota actualizada correctamente")
        : Results.BadRequest("No se pudo actualizar la nota porque esta finalizada");
})
.WithName("UpdateNota");






app.Run();


