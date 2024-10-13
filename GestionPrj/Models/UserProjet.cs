using System.ComponentModel.DataAnnotations.Schema;

namespace GestionPrj.Models
{
    public class UserProjet
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public User User { get; set; }
        public int UserId { get; set; }

        public Projet Projet { get; set; }
        public int ProjetId { get; set; }
    }
}
