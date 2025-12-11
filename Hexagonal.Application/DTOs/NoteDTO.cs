namespace Hexagonal.Application.DTOs
{
    public class NoteDTO
    {
        public int Id { get; set; }
        public int ItemId { get; set; }
        public string Message { get; set; }

        //El signo de interrogacion indica que el campo puede ser nulo
        public string? Color { get; set; }
    }
}
