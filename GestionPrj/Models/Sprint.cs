using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestionPrj.Models
{
    public class Sprint
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required(ErrorMessage = "le nom  est requis")]
        public string Nom { get; set; }
        [Required(ErrorMessage = "la date debut est requise")]
        public DateTime Date_debut { get; set; }
        [Required(ErrorMessage = "la date fin est requise")]
        public DateTime Date_fin { get; set;}
       
        [Required(ErrorMessage = "Sprint Backlog est requis")]
        public string Sprint_Backlog { get; set; }

        public Projet? Projet { get; set; }
        public int? ProjetId { get; set; }

        public RScrum? RScrum { get; set; }
        public int? RScrumId { get; set; }

      public List<UserStory>? UserStories { get; set; }



    }
}
