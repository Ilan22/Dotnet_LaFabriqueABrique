using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LaFabriqueaBriques.Models
{
    public class Lego
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        [NotMapped]
        public string ImageUrlsInput { get; set; }

        public List<string> ImageUrls { get; set; } = new List<string>();

        [Range(0, double.MaxValue, ErrorMessage = "Le prix doit être positif.")]
        public decimal Price { get; set; }

        [Range(0, 100, ErrorMessage = "L'âge recommandé doit être compris entre 0 et 100.")]
        public int Age { get; set; }

        public int NbPiece { get; set; }
    }
}
