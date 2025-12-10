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