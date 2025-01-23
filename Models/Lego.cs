using System.ComponentModel.DataAnnotations;

namespace LaFabriqueaBriques.Models
{
    public class Lego
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        public string Description { get; set; } = string.Empty;

        [Required]
        public List<string> ImageUrls { get; set; } = new List<string>();

        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "Le prix doit être positif.")]
        public decimal Price { get; set; }

        [Required]
        [Range(0, 100, ErrorMessage = "L'âge recommandé doit être compris entre 0 et 100.")]
        public int Age { get; set; }

        [Required]
        public int NbPiece { get; set; }

        // Relation avec User
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
