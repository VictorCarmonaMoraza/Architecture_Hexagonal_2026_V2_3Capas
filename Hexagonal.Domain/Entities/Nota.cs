namespace Hexagonal.Domain.Entities
{
    public class Nota
    {
        public int Id { get; set; }
        public int ItemId { get; private set; }
        public string Message { get; private set; }

        public Nota(int id, int itemId, string message)
        {
            if (string.IsNullOrEmpty(message))
            {
                throw new ArgumentException("Message cannot be null or empty", nameof(message));
            }
            if (message.Length > 100)
            {
                throw new ArgumentException("Message cannot be longer than 100 characters", nameof(message));
            }

            Id = id;
            ItemId = itemId;
            Message = message;
        }

        public void UpdateMessage(string message)
        {
            if (string.IsNullOrEmpty(message))
            {
                throw new ArgumentException("Message cannot be null or empty", nameof(message));
            }
            if (message.Length > 100)
            {
                throw new ArgumentException("Message cannot be longer than 100 characters", nameof(message));
            }
            Message = message;
        }
    }

}

