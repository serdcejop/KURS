using System;

namespace AUTOO.Models
{
    public enum EmployeeType
    {
        Mechanic,
        Welder,
        Fitter,
        Assembler,
        Technician,
        TeamLeader,
        Foreman,
        DepartmentHead,
        WorkshopHead
    }

    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public EmployeeType Position { get; set; }
        public int? TeamId { get; set; }
        public int? SupervisorId { get; set; }
        public DateTime HireDate { get; set; }
    }
}