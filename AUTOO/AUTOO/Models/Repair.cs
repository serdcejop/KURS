using System;
using System.Collections.Generic;

namespace AUTOO.Models
{
    public class Repair
    {
        public int Id { get; set; }
        public int VehicleId { get; set; }
        public DateTime RepairDate { get; set; }
        public decimal Cost { get; set; }
        public string Description { get; set; }
        public List<ReplacedPart> ReplacedParts { get; set; } = new List<ReplacedPart>();
        public List<int> EmployeeIds { get; set; } = new List<int>();
    }

    public class ReplacedPart
    {
        public string PartName { get; set; }
        public string PartType { get; set; } // двигатель, коробка передач и т.д.
        public int Quantity { get; set; }
        public decimal UnitCost { get; set; }
    }
}