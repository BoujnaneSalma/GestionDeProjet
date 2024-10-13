using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestionPrj.Models
{
    public class Tache
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required(ErrorMessage = "la Description  est requise")]
        public string? Description { get; set; }
        [Required(ErrorMessage = "le Temps est requis")]
        public int? Estimation_Temps { get; set; }
        public UserStory? UserStory { get; set; }
        public int UserStoryId { get; set; }


    }
}
