using AUTOO.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AUTOO.Services
{
    public class DataService
    {
        private List<Vehicle> _vehicles;
        private List<Driver> _drivers;
        private List<Employee> _employees;
        private List<Repair> _repairs;
        private List<Garage> _garages;
        private List<Route> _routes;
        private List<CargoTransportation> _cargoTransportations;

        public DataService()
        {
            InitializeSampleData();
        }

        private void InitializeSampleData()
        {
            // Инициализация гаражей
            _garages = new List<Garage>
            {
                new Garage { Id = 1, Name = "Главный гараж", Address = "ул. Транспортная, 1", Capacity = 50, Type = "гараж" },
                new Garage { Id = 2, Name = "Цех ремонта", Address = "ул. Мастеровая, 5", Capacity = 20, Type = "цех" }
            };

            // Инициализация маршрутов
            _routes = new List<Route>
            {
                new Route { Id = 1, RouteNumber = "101", StartPoint = "Вокзал", EndPoint = "Аэропорт", Length = 15.5 },
                new Route { Id = 2, RouteNumber = "205", StartPoint = "Центр", EndPoint = "Западный район", Length = 8.2 }
            };

            // Инициализация транспорта
            _vehicles = new List<Vehicle>
            {
                new Vehicle 
                { 
                    Id = 1, 
                    LicensePlate = "А001АА", 
                    Brand = "ГАЗ", 
                    Model = "ГАЗель NEXT", 
                    Type = VehicleType.Truck,
                    DriverId = 1,
                    LoadCapacity = 1500,
                    PurchaseDate = new DateTime(2022, 1, 15),
                    CurrentMileage = 45000,
                    GarageId = 1
                },
                new Vehicle 
                { 
                    Id = 2, 
                    LicensePlate = "Б002ББ", 
                    Brand = "ЛиАЗ", 
                    Model = "5256", 
                    Type = VehicleType.Bus,
                    DriverId = 2,
                    Capacity = 85,
                    PurchaseDate = new DateTime(2021, 5, 20),
                    CurrentMileage = 125000,
                    GarageId = 1,
                    RouteId = 1
                },
                new Vehicle 
                { 
                    Id = 3, 
                    LicensePlate = "В003ВВ", 
                    Brand = "Hyundai", 
                    Model = "Solaris", 
                    Type = VehicleType.Taxi,
                    DriverId = 3,
                    Capacity = 4,
                    PurchaseDate = new DateTime(2023, 3, 10),
                    CurrentMileage = 25000,
                    GarageId = 2
                }
            };

            // Инициализация водителей
            _drivers = new List<Driver>
            {
                new Driver { Id = 1, FirstName = "Иван", LastName = "Иванов", LicenseNumber = "ВОД1234", VehicleId = 1 },
                new Driver { Id = 2, FirstName = "Петр", LastName = "Петров", LicenseNumber = "ВОД5678", VehicleId = 2 },
                new Driver { Id = 3, FirstName = "Сергей", LastName = "Сергеев", LicenseNumber = "ВОД9012", VehicleId = 3 }
            };

            // Инициализация сотрудников
            _employees = new List<Employee>
            {
                new Employee { Id = 1, FirstName = "Алексей", LastName = "Кузнецов", Position = EmployeeType.DepartmentHead, HireDate = new DateTime(2018, 6, 1) },
                new Employee { Id = 2, FirstName = "Михаил", LastName = "Попов", Position = EmployeeType.Foreman, SupervisorId = 1, HireDate = new DateTime(2020, 2, 15) },
                new Employee { Id = 3, FirstName = "Дмитрий", LastName = "Васильев", Position = EmployeeType.TeamLeader, SupervisorId = 2, HireDate = new DateTime(2021, 9, 10) },
                new Employee { Id = 4, FirstName = "Андрей", LastName = "Смирнов", Position = EmployeeType.Mechanic, SupervisorId = 3, HireDate = new DateTime(2022, 3, 5) },
                new Employee { Id = 5, FirstName = "Николай", LastName = "Морозов", Position = EmployeeType.Welder, SupervisorId = 3, HireDate = new DateTime(2021, 11, 20) }
            };

            // Инициализация ремонтов
            _repairs = new List<Repair>
            {
                new Repair 
                { 
                    Id = 1, 
                    VehicleId = 1, 
                    RepairDate = new DateTime(2024, 1, 10), 
                    Cost = 25000,
                    Description = "Замена тормозных колодок",
                    EmployeeIds = new List<int> { 4 },
                    ReplacedParts = new List<ReplacedPart>
                    {
                        new ReplacedPart { PartName = "Тормозные колодки", PartType = "Тормозная система", Quantity = 4, UnitCost = 2000 }
                    }
                },
                new Repair 
                { 
                    Id = 2, 
                    VehicleId = 2, 
                    RepairDate = new DateTime(2024, 2, 15), 
                    Cost = 50000,
                    Description = "Ремонт двигателя",
                    EmployeeIds = new List<int> { 4, 5 },
                    ReplacedParts = new List<ReplacedPart>
                    {
                        new ReplacedPart { PartName = "Поршневая группа", PartType = "Двигатель", Quantity = 1, UnitCost = 35000 }
                    }
                }
            };

            // Инициализация грузоперевозок
            _cargoTransportations = new List<CargoTransportation>
            {
                new CargoTransportation 
                { 
                    Id = 1, 
                    VehicleId = 1, 
                    Date = new DateTime(2024, 1, 20), 
                    CargoType = "Строительные материалы",
                    Weight = 1200,
                    Distance = 200,
                    Revenue = 40000,
                    Client = "СтройКомпания"
                },
                new CargoTransportation 
                { 
                    Id = 2, 
                    VehicleId = 1, 
                    Date = new DateTime(2024, 2, 5), 
                    CargoType = "Бытовая техника",
                    Weight = 800,
                    Distance = 150,
                    Revenue = 30000,
                    Client = "Магазин Техники"
                }
            };
        }

        // Методы для получения данных
        public List<Vehicle> GetVehicles() => _vehicles;
        public List<Driver> GetDrivers() => _drivers;
        public List<Employee> GetEmployees() => _employees;
        public List<Repair> GetRepairs() => _repairs;
        public List<Garage> GetGarages() => _garages;
        public List<Route> GetRoutes() => _routes;
        public List<CargoTransportation> GetCargoTransportations() => _cargoTransportations;

        // Методы для добавления данных
        public void AddVehicle(Vehicle vehicle) => _vehicles.Add(vehicle);
        public void AddDriver(Driver driver) => _drivers.Add(driver);
        public void AddRepair(Repair repair) => _repairs.Add(repair);
        public void AddCargoTransportation(CargoTransportation cargo) => _cargoTransportations.Add(cargo);
    }
}