using System;
using System.Collections.Generic;

namespace AUTOO.Models
{
    public enum VehicleType
    {
        Bus,
        Taxi,
        Minibus,
        Truck,
        Utility,
        Other
    }

    public class Vehicle
    {
        public int Id { get; set; }
        public string LicensePlate { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public VehicleType Type { get; set; }
        public int? DriverId { get; set; }
        public int? Capacity { get; set; } // Для пассажирского транспорта
        public double? LoadCapacity { get; set; } // Для грузового транспорта
        public DateTime PurchaseDate { get; set; }
        public DateTime? WriteOffDate { get; set; }
        public int CurrentMileage { get; set; }
        public int? GarageId { get; set; }
        public int? RouteId { get; set; }
    }
}