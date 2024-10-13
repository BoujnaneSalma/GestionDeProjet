using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestionPrj.Models
{
    public class RScrum
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Le nom de la réunion est requis")]
        public string Type { get; set; }

        [Required(ErrorMessage = "La date de la réunion est requise")]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "L'heure de début est requise")]
        public TimeSpan HeureDebut { get; set; }

        [Required(ErrorMessage = "L'heure de fin est requise")]
        public TimeSpan HeureFin { get; set; }

        public string Description { get; set; }

        public  List<Sprint>? Sprints { get; set; }



    }
}
