using Hexagonal.Application.Case_Uso;
using Hexagonal.Application.Port_Primary;
using Hexagonal.Domain.interfaces;
using Hexagonal.Infraestructure.DBContext;
using Hexagonal.Infraestructure.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

var configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .Build();

string connectionString = configuration.GetConnectionString("DefaultConnection")!;

//Inyector de dependecias
var service = new ServiceCollection();
service.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

//Implementaciones de los puertos
service.AddTransient<IItemRepository, ItemRepository>();
service.AddTransient<IItemService, ItemService>();

//Creacion de objeto a partir de lo que inyectamos
var serviceProvider = service.BuildServiceProvider();
var itemsService = serviceProvider.GetRequiredService<IItemService>();



while (true)
{
    try
    {
        Console.WriteLine("\nSeleccione una opcion");
        Console.WriteLine("1- Agregar una tarea");
        Console.WriteLine("2- Mostrar tareas");
        Console.WriteLine("3- Finalizar tarea por Id");
        Console.WriteLine("4- Salir");

        var option = Console.ReadLine();
        switch (option)
        {
            case "1":
                Console.WriteLine("Ingrese el titulo de la tarea:");
                var title = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(title))
                {
                    await itemsService.AddItemAsync(title);
                    Console.WriteLine("Tarea agregada exitosamente.");
                }
                else
                {
                    Console.WriteLine("El titulo no puede estar vacio.");
                }
                break;
            case "2":
                Console.WriteLine("Obteniendo tareas...");
                var items = await itemsService.GetAllItemsAsync();
                Console.WriteLine("\nTareas almacenadas:");
                foreach (var item in items)
                {
                    Console.WriteLine($"- [{(item.IsCompleted ? "X" : " ")}] {item.Title} (ID: {item.Id})");
                }
                break;
            case "3":
                Console.WriteLine("Dame el id de la tarea que quieres establecer como finalizada");
                var optionId = Console.ReadLine();
                if (int.TryParse(optionId, out int id))
                {
                    await itemsService.UpdateItemById(id);
                    Console.WriteLine("Tarea actualizada exitosamente.");
                }
                else
                {
                    Console.WriteLine("ID invalido. Intente de nuevo.");
                }
                break;
            case "4":
                return;
            default:
                Console.WriteLine("Opcion no valida. Intente de nuevo.");
                break;
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error: {ex.Message}");
    }

}