using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LaFabriqueaBriques.Models
{
    public class Order
    {
        public int Id { get; set; } // Clé primaire

        [Required]
        public int UserId { get; set; } // Clé étrangère pour l'utilisateur

        public User User { get; set; } // Navigation vers l'utilisateur

        public List<Lego> Legos { get; set; } = new List<Lego>(); // Liste des Legos de la commande
        
        [Required]
        public DateTime OrderDate { get; set; } = DateTime.Now;

        [Required]
        public decimal TotalPrice { get; set; } // Prix total de la commande
    }
}
