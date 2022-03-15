namespace teemUpAPI.Models
{
    public class license
    {
        public int Id { get; set; }
        public int userId { get; set; }
        public Users? users { get; set; }
        public DateTime registrationDate { get; set; }
        public int licenseTypesId { get; set; }
        public licenseTypes? licenseTypes { get; set; }
        public DateTime? expirationDate { get; set; }
        
    }
}
