using System.ComponentModel.DataAnnotations.Schema;

namespace GestionPrj.Models
{
    public class UserReunion
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public User User { get; set; }
        public int UserId { get; set; }

        public RScrum RScrum { get; set; }
        public int RScrumId { get; set; }
    }
}
