namespace UdemyBackend.DTOs
{
    public class PostDto
    {
        // El ? indica que la propiedad puede ser nula
        public int Id { get; set; }
        public int UserId { get; set; }
        public string? Title { get; set; }
        public string? Body { get; set; }
    }
}
