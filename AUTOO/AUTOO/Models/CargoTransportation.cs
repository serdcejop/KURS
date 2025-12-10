using System;

namespace AUTOO.Models
{
    public class CargoTransportation
    {
        public int Id { get; set; }
        public int VehicleId { get; set; }
        public DateTime Date { get; set; }
        public string CargoType { get; set; }
        public double Weight { get; set; }
        public decimal Distance { get; set; }
        public decimal Revenue { get; set; }
        public string Client { get; set; }
    }
}