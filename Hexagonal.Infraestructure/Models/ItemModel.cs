//Tabla de la base de datos
namespace Hexagonal.Infraestructure.Models
{
    public class ItemModel
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime CreatedDate { get; set; }
        public ICollection<NoteModel>? Notes { get; set; }
    }
}
