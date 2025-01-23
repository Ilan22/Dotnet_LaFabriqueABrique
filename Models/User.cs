using LaFabriqueaBriques.Models;

namespace LaFabriqueaBriques.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public List<Lego> Legos { get; set; } = new List<Lego>();
    }
}