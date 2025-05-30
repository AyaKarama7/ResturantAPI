using System.Net.Sockets;

namespace Resturant.Domain.Entities
{
    public class Resturant
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
        public string Category { get; set; } = default!;
        public bool HasDelivery { get; set; }
        public string? Email { get; set; }
        public string? ContactNumber { get; set; }  
        public string? LogoUrl {  get; set; }
        public TimeOnly Opening { get; set; }
        public TimeOnly Closing { get; set; }
        public Address? Address { get; set; }
        public List<Dish> Dishes { get; set; } = new();
        public User Owner { get; set; } = default!;
        public string OwnerId { get; set; } = default!;
    }
}
