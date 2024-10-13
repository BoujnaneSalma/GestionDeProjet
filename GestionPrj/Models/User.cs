using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestionPrj.Models
{
    public class User
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required(ErrorMessage = "le nom est requis")]
        public string Nom { get; set; }
        [Required(ErrorMessage = "le Prenom est requis")]
        public string Prenom { get; set; }
        
        [Required(ErrorMessage = "la photo est requise")]
        public string? Photo { get; set; }
        [Required(ErrorMessage = "l'email est requis")]
        public string Email { get; set; }
        [Required(ErrorMessage = "le mot de passe est requis")]
        public string Password { get; set; }
        [Required(ErrorMessage = "le Role est requis")]
        public string Role { get; set; }

        public List<UserProjet>? UProjets { get; set; }
        
        public List<UserStory>? UserStories { get; set; }
    }
}
