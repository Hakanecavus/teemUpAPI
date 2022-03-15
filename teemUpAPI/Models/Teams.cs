using System.ComponentModel.DataAnnotations;

namespace teemUpAPI.Models
{
    public class Teams
    {
        [Key]
        public int teamId { get; set; }
        [StringLength(50)]
        public string teamName { get; set; }
        public int userId { get; set; }
        public Users? user { get; set; }

    }
}
