namespace teemUpAPI.Models
{
    public class teamMembers
    {
        public int Id { get; set; }
        public int teamId { get; set; }
        public Teams? team { get; set; }
        public int userId { get; set; }
        public Users? user { get; set; }
        public int userPositionId { get; set; }
        public userPositions? userPosition { get; set; }


    }
}
