using LaFabriqueaBriques.Models;

namespace LaFabriqueaBriques.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public int Role { get; set; }
        public List<UserLego> UserLegos { get; set; }
        public List<Lego> Cart { get; set; } = new List<Lego>();
        public List<Order> Orders { get; set; } = new List<Order>();

    }
}