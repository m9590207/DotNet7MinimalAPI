namespace Domain.Models
{
    public class SuperHero
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Place { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime LastModified { get; set; }
    }
}
