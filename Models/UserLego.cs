namespace LaFabriqueaBriques.Models
{
    public class UserLego
    {
        public int UserId { get; set; }
        public User User { get; set; }

        public int LegoId { get; set; }
        public Lego Lego { get; set; }
    }
}
