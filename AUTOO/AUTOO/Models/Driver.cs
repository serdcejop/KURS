namespace AUTOO.Models
{
    public class Driver
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string LicenseNumber { get; set; }
        public int? TeamId { get; set; }
        public int? VehicleId { get; set; }
    }
}