using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestionPrj.Models
{
    public class Projet
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required(ErrorMessage = "le nom est requis")]
        public string? Nom { get; set; }
        [Required(ErrorMessage = "la description est requise")]
        public string Description { get; set; }
        [Required(ErrorMessage = "la date debut est requise")]
        public DateTime Date_debut { get; set; }
        [Required(ErrorMessage = "la date fin est requise")]
        public DateTime Date_fin { get; set;}
        

        public List<UserProjet>? UProjets { get; set; }

        public List<UserStory>? UserStories { get; set; }

        public List<Sprint>? Sprints { get; set; }

    }
}
