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
            modelBuilder.Entity<NoteModel>().ToTable("Note")
                .HasOne(n=>n.Item)
                .WithMany(i=>i.Notes)
                .HasForeignKey(n=>n.ItemId)
                .OnDelete(DeleteBehavior.Cascade);
        }

        public DbSet<ItemModel> ItemsModel { get; set; }
        public DbSet<NoteModel> NotesModel { get; set; }
    }
}
