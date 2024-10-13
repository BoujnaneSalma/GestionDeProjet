using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GestionPrj.Models
{
    public class UserStory
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required(ErrorMessage = "Description est requise")]
        public string? Description { get; set; }
        [Required(ErrorMessage = "Prioritie est requis")]
        public string Priority { get; set; }
        [Required(ErrorMessage = "l'etat est requise")]
        public string Etat { get; set; }

        public User? User { get; set; }
        public int? UserId { get; set; }

        public Projet? Projet { get; set; }
        public int? ProjetId { get; set; }

        public Sprint? Sprint { get; set; }
        public int? SprintId { get; set;}
        public List<Tache>? Taches { get; set; }


    }
}
