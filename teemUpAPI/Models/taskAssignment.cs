namespace teemUpAPI.Models
{
    public class taskAssignment
    {
        public int Id { get; set; }
        public int taskId { get; set; }
        public Tasks? tasks { get; set; }
        public int userId { get; set; }
        public Users? users { get; set; }
        public int dutyId { get; set; }
        public dutyTypes? dutyTypes { get; set; }
        public string progress { get; set; }
        public int lineId { get; set; }

    }
}