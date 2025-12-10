using Hexagonal.Infraestructure.Models;
using Microsoft.EntityFrameworkCore;

namespace Hexagonal.Infraestructure.DBContext
{
    public class ApplicationDbContext : DbContext
    {
        

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Mapeamos nuestro modelo contra la tabla de la base de datos
            modelBuilder.Entity<ItemModel>().ToTable("Items");
        }

        public DbSet<ItemModel> ItemsModel { get; set; }
    }
}
