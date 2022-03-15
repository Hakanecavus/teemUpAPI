using System.ComponentModel.DataAnnotations;

namespace teemUpAPI.Models
{
    public class Users
    {
        [Key]
        public int userId { get; set; }

        [StringLength(20)]
        public string name { get; set; }
        public string surname { get; set; }

        [StringLength(50)]
        public string email { get; set; }

    }
}
