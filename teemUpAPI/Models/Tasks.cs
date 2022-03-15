using System.ComponentModel.DataAnnotations;

namespace teemUpAPI.Models
{
    public class Tasks
    {
        [Key]
        public int taskId { get; set; }
        public int lineNum { get; set; }

        [StringLength(100)]
        public string definition { get; set; } = string.Empty;
        public DateTime createDate { get; set; } = DateTime.Today;
        public DateTime? dueDate { get; set; }

        public int UserId { get; set; }
        public Users? User { get; set; }

        public int TeamId { get; set; }
        public Teams? team { get; set; }


        
    }
}
