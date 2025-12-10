using Microsoft.Extensions.Configuration;

var configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json", optional:false,reloadOnChange:true)
    .Build();

string connectionString = configuration.GetConnectionString("DefaultConnection");