using AUTOO.Models;
using AUTOO.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace AUTOO.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private readonly DataService _dataService;
        private ObservableCollection<Vehicle> _vehicles;
        private ObservableCollection<Driver> _drivers;
        private ObservableCollection<Employee> _employees;
        private ObservableCollection<Repair> _repairs;
        private ObservableCollection<Garage> _garages;
        private ObservableCollection<Route> _routes;
        private ObservableCollection<CargoTransportation> _cargoTransportations;
        private Vehicle _selectedVehicle;
        private Driver _selectedDriver;
        private Employee _selectedEmployee;
        private string _statusMessage;

        public ObservableCollection<Vehicle> Vehicles
        {
            get => _vehicles;
            set => SetProperty(ref _vehicles, value);
        }

        public ObservableCollection<Driver> Drivers
        {
            get => _drivers;
            set => SetProperty(ref _drivers, value);
        }

        public ObservableCollection<Employee> Employees
        {
            get => _employees;
            set => SetProperty(ref _employees, value);
        }

        public ObservableCollection<Repair> Repairs
        {
            get => _repairs;
            set => SetProperty(ref _repairs, value);
        }

        public ObservableCollection<Garage> Garages
        {
            get => _garages;
            set => SetProperty(ref _garages, value);
        }

        public ObservableCollection<Route> Routes
        {
            get => _routes;
            set => SetProperty(ref _routes, value);
        }

        public ObservableCollection<CargoTransportation> CargoTransportations
        {
            get => _cargoTransportations;
            set => SetProperty(ref _cargoTransportations, value);
        }

        public Vehicle SelectedVehicle
        {
            get => _selectedVehicle;
            set => SetProperty(ref _selectedVehicle, value);
        }

        public Driver SelectedDriver
        {
            get => _selectedDriver;
            set => SetProperty(ref _selectedDriver, value);
        }

        public Employee SelectedEmployee
        {
            get => _selectedEmployee;
            set => SetProperty(ref _selectedEmployee, value);
        }

        public string StatusMessage
        {
            get => _statusMessage;
            set => SetProperty(ref _statusMessage, value);
        }

        // Команды для основных действий
        public ICommand AddVehicleCommand { get; }
        public ICommand DeleteVehicleCommand { get; }
        public ICommand AddDriverCommand { get; }
        public ICommand DeleteDriverCommand { get; }
        public ICommand AddRepairCommand { get; }
        public ICommand AddCargoTransportationCommand { get; }
        public ICommand ShowStatisticsCommand { get; }

        // Команды для запросов (1-13)
        public ICommand Query1Command { get; }
        public ICommand Query2Command { get; }
        public ICommand Query3Command { get; }
        public ICommand Query4Command { get; }
        public ICommand Query5Command { get; }
        public ICommand Query6Command { get; }
        public ICommand Query7Command { get; }
        public ICommand Query8Command { get; }
        public ICommand Query9Command { get; }
        public ICommand Query10Command { get; }
        public ICommand Query11Command { get; }
        public ICommand Query12Command { get; }
        public ICommand Query13Command { get; }

        public MainViewModel()
        {
            _dataService = new DataService();
            InitializeData();

            // Основные команды
            AddVehicleCommand = new RelayCommand(AddVehicle);
            DeleteVehicleCommand = new RelayCommand(DeleteVehicle, CanDeleteVehicle);
            AddDriverCommand = new RelayCommand(AddDriver);
            DeleteDriverCommand = new RelayCommand(DeleteDriver, CanDeleteDriver);
            AddRepairCommand = new RelayCommand(AddRepair);
            AddCargoTransportationCommand = new RelayCommand(AddCargoTransportation);
            ShowStatisticsCommand = new RelayCommand(ShowStatistics);

            // Команды запросов
            Query1Command = new RelayCommand(ExecuteQuery1);
            Query2Command = new RelayCommand(ExecuteQuery2);
            Query3Command = new RelayCommand(ExecuteQuery3);
            Query4Command = new RelayCommand(ExecuteQuery4);
            Query5Command = new RelayCommand(ExecuteQuery5);
            Query6Command = new RelayCommand(ExecuteQuery6);
            Query7Command = new RelayCommand(ExecuteQuery7);
            Query8Command = new RelayCommand(ExecuteQuery8);
            Query9Command = new RelayCommand(ExecuteQuery9);
            Query10Command = new RelayCommand(ExecuteQuery10);
            Query11Command = new RelayCommand(ExecuteQuery11);
            Query12Command = new RelayCommand(ExecuteQuery12);
            Query13Command = new RelayCommand(ExecuteQuery13);
        }

        private void InitializeData()
        {
            Vehicles = new ObservableCollection<Vehicle>(_dataService.GetVehicles());
            Drivers = new ObservableCollection<Driver>(_dataService.GetDrivers());
            Employees = new ObservableCollection<Employee>(_dataService.GetEmployees());
            Repairs = new ObservableCollection<Repair>(_dataService.GetRepairs());
            Garages = new ObservableCollection<Garage>(_dataService.GetGarages());
            Routes = new ObservableCollection<Route>(_dataService.GetRoutes());
            CargoTransportations = new ObservableCollection<CargoTransportation>(_dataService.GetCargoTransportations());
        }

        #region Основные действия
        private void AddVehicle(object parameter)
        {
            var newVehicle = new Vehicle
            {
                Id = Vehicles.Count + 1,
                LicensePlate = $"А{Vehicles.Count + 100:000}АА",
                Brand = "Новая марка",
                Model = "Новая модель",
                Type = VehicleType.Other,
                PurchaseDate = DateTime.Now
            };
            Vehicles.Add(newVehicle);
            StatusMessage = $"Добавлено транспортное средство: {newVehicle.LicensePlate}";
        }

        private void DeleteVehicle(object parameter)
        {
            if (SelectedVehicle != null)
            {
                var vehicle = SelectedVehicle;
                Vehicles.Remove(vehicle);
                StatusMessage = $"Удалено транспортное средство: {vehicle.LicensePlate}";
            }
        }

        private bool CanDeleteVehicle(object parameter)
        {
            return SelectedVehicle != null;
        }

        private void AddDriver(object parameter)
        {
            var newDriver = new Driver
            {
                Id = Drivers.Count + 1,
                FirstName = "Новый",
                LastName = "Водитель",
                LicenseNumber = $"ВОД{Drivers.Count + 1000:0000}"
            };
            Drivers.Add(newDriver);
            StatusMessage = $"Добавлен водитель: {newDriver.LastName} {newDriver.FirstName}";
        }

        private void DeleteDriver(object parameter)
        {
            if (SelectedDriver != null)
            {
                var driver = SelectedDriver;
                Drivers.Remove(driver);
                StatusMessage = $"Удален водитель: {driver.LastName} {driver.FirstName}";
            }
        }

        private bool CanDeleteDriver(object parameter)
        {
            return SelectedDriver != null;
        }

        private void AddRepair(object parameter)
        {
            if (SelectedVehicle == null)
            {
                StatusMessage = "Выберите транспортное средство для добавления ремонта";
                return;
            }

            var newRepair = new Repair
            {
                Id = Repairs.Count + 1,
                VehicleId = SelectedVehicle.Id,
                RepairDate = DateTime.Now,
                Cost = 5000,
                Description = "Плановый ремонт"
            };
            Repairs.Add(newRepair);
            StatusMessage = $"Добавлен ремонт для {SelectedVehicle.LicensePlate} на сумму {newRepair.Cost:C}";
        }

        private void AddCargoTransportation(object parameter)
        {
            if (SelectedVehicle == null || SelectedVehicle.Type != VehicleType.Truck)
            {
                StatusMessage = "Выберите грузовой транспорт для добавления перевозки";
                return;
            }

            var newCargo = new CargoTransportation
            {
                Id = CargoTransportations.Count + 1,
                VehicleId = SelectedVehicle.Id,
                Date = DateTime.Now,
                CargoType = "Различные товары",
                Weight = 2000,
                Distance = 150,
                Revenue = 50000
            };
            CargoTransportations.Add(newCargo);
            StatusMessage = $"Добавлена грузоперевозка для {SelectedVehicle.LicensePlate}, доход: {newCargo.Revenue:C}";
        }

        private void ShowStatistics(object parameter)
        {
            var stats = new StatisticsWindow();
            stats.DataContext = this;
            stats.Show();
        }
        #endregion

        #region Реализация запросов (1-13)
        private void ExecuteQuery1(object parameter)
        {
            string result = $"Общий автопарк: {Vehicles.Count} единиц\n";
            result += $"Автобусы: {Vehicles.Count(v => v.Type == VehicleType.Bus)}\n";
            result += $"Грузовой транспорт: {Vehicles.Count(v => v.Type == VehicleType.Truck)}\n";
            result += $"Такси: {Vehicles.Count(v => v.Type == VehicleType.Taxi)}\n";
            result += $"Маршрутные такси: {Vehicles.Count(v => v.Type == VehicleType.Minibus)}";

            ShowMessageBox("1. Данные об автопарке предприятия", result);
        }

        private void ExecuteQuery2(object parameter)
        {
            string result = $"Общее число водителей: {Drivers.Count}\n\n";

            if (SelectedVehicle != null)
            {
                var vehicleDrivers = Drivers.Where(d => d.VehicleId == SelectedVehicle.Id);
                result += $"Водители для {SelectedVehicle.LicensePlate}:\n";
                foreach (var driver in vehicleDrivers)
                {
                    result += $"- {driver.LastName} {driver.FirstName} ({driver.LicenseNumber})\n";
                }
            }
            else
            {
                result += "Все водители:\n";
                foreach (var driver in Drivers)
                {
                    result += $"- {driver.LastName} {driver.FirstName} ({driver.LicenseNumber})\n";
                }
            }

            ShowMessageBox("2. Водители предприятия", result);
        }

        private void ExecuteQuery3(object parameter)
        {
            string result = "Распределение водителей по автомобилям:\n\n";

            foreach (var vehicle in Vehicles)
            {
                var driver = Drivers.FirstOrDefault(d => d.VehicleId == vehicle.Id);
                result += $"{vehicle.LicensePlate} ({vehicle.Brand} {vehicle.Model}): ";
                result += driver != null ? $"{driver.LastName} {driver.FirstName}\n" : "Нет водителя\n";
            }

            ShowMessageBox("3. Распределение водителей", result);
        }

        private void ExecuteQuery4(object parameter)
        {
            string result = "Пассажирский транспорт по маршрутам:\n\n";

            var passengerVehicles = Vehicles.Where(v =>
                v.Type == VehicleType.Bus ||
                v.Type == VehicleType.Taxi ||
                v.Type == VehicleType.Minibus);

            foreach (var vehicle in passengerVehicles)
            {
                var route = Routes.FirstOrDefault(r => r.Id == vehicle.RouteId);
                result += $"{vehicle.LicensePlate} ({vehicle.Type}): ";
                result += route != null ? $"Маршрут {route.RouteNumber}: {route.StartPoint} - {route.EndPoint}\n" : "Нет маршрута\n";
            }

            ShowMessageBox("4. Транспорт по маршрутам", result);
        }

        private void ExecuteQuery5(object parameter)
        {
            // Здесь обычно будет диалог для выбора периода
            string result = "Пробег транспорта:\n\n";

            if (SelectedVehicle != null)
            {
                result += $"{SelectedVehicle.LicensePlate}: {SelectedVehicle.CurrentMileage} км\n";
            }
            else
            {
                result += "Общий пробег по типам:\n";
                foreach (var type in Enum.GetValues(typeof(VehicleType)).Cast<VehicleType>())
                {
                    var totalMileage = Vehicles.Where(v => v.Type == type).Sum(v => v.CurrentMileage);
                    result += $"{type}: {totalMileage} км\n";
                }
            }

            ShowMessageBox("5. Пробег транспорта", result);
        }

        private void ExecuteQuery6(object parameter)
        {
            string result = "Статистика ремонтов:\n\n";

            if (SelectedVehicle != null)
            {
                var vehicleRepairs = Repairs.Where(r => r.VehicleId == SelectedVehicle.Id);
                result += $"Ремонты для {SelectedVehicle.LicensePlate}:\n";
                result += $"Количество: {vehicleRepairs.Count()}\n";
                result += $"Общая стоимость: {vehicleRepairs.Sum(r => r.Cost):C}\n";
            }
            else
            {
                result += "Все ремонты:\n";
                result += $"Общее количество: {Repairs.Count}\n";
                result += $"Общая стоимость: {Repairs.Sum(r => r.Cost):C}\n";
            }

            ShowMessageBox("6. Статистика ремонтов", result);
        }

        private void ExecuteQuery7(object parameter)
        {
            string result = "Структура персонала:\n\n";

            // Начальники
            var heads = Employees.Where(e => e.Position == EmployeeType.DepartmentHead ||
                                            e.Position == EmployeeType.WorkshopHead);
            foreach (var head in heads)
            {
                result += $"{head.Position}: {head.LastName} {head.FirstName}\n";

                // Мастера под начальником
                var masters = Employees.Where(e => e.SupervisorId == head.Id);
                foreach (var master in masters)
                {
                    result += $"  Мастер: {master.LastName} {master.FirstName}\n";

                    // Бригадиры под мастером
                    var teamLeaders = Employees.Where(e => e.SupervisorId == master.Id);
                    foreach (var teamLeader in teamLeaders)
                    {
                        result += $"    Бригадир: {teamLeader.LastName} {teamLeader.FirstName}\n";
                    }
                }
                result += "\n";
            }

            ShowMessageBox("7. Структура персонала", result);
        }

        private void ExecuteQuery8(object parameter)
        {
            string result = "Гаражное хозяйство:\n\n";

            foreach (var garage in Garages)
            {
                var vehiclesInGarage = Vehicles.Count(v => v.GarageId == garage.Id);
                result += $"{garage.Name} ({garage.Type}):\n";
                result += $"  Адрес: {garage.Address}\n";
                result += $"  Вместимость: {garage.Capacity}\n";
                result += $"  Заполнено: {vehiclesInGarage} из {garage.Capacity}\n\n";
            }

            ShowMessageBox("8. Гаражное хозяйство", result);
        }

        private void ExecuteQuery9(object parameter)
        {
            string result = "Грузоперевозки:\n\n";

            if (SelectedVehicle != null)
            {
                var cargoForVehicle = CargoTransportations.Where(c => c.VehicleId == SelectedVehicle.Id);
                result += $"Грузоперевозки для {SelectedVehicle.LicensePlate}:\n";
                foreach (var cargo in cargoForVehicle)
                {
                    result += $"{cargo.Date:d}: {cargo.CargoType}, {cargo.Weight}кг, {cargo.Distance}км\n";
                }
            }
            else
            {
                var totalCargo = CargoTransportations.Sum(c => c.Weight);
                var totalRevenue = CargoTransportations.Sum(c => c.Revenue);
                result += $"Всего перевезено: {totalCargo}кг\n";
                result += $"Общий доход: {totalRevenue:C}\n";
            }

            ShowMessageBox("9. Грузоперевозки", result);
        }

        private void ExecuteQuery10(object parameter)
        {
            string result = "Узлы и агрегаты для ремонта:\n\n";

            var allParts = Repairs.SelectMany(r => r.ReplacedParts);
            result += $"Всего заменено узлов: {allParts.Sum(p => p.Quantity)}\n\n";

            var groupedParts = allParts.GroupBy(p => p.PartType);
            foreach (var group in groupedParts)
            {
                result += $"{group.Key}: {group.Sum(p => p.Quantity)} шт.\n";
            }

            ShowMessageBox("10. Узлы и агрегаты", result);
        }

        private void ExecuteQuery11(object parameter)
        {
            string result = "Поступление и списание техники:\n\n";

            var purchasedVehicles = Vehicles.Where(v => v.PurchaseDate.Year == DateTime.Now.Year);
            var writtenOffVehicles = Vehicles.Where(v => v.WriteOffDate.HasValue &&
                                                        v.WriteOffDate.Value.Year == DateTime.Now.Year);

            result += $"Поступило в этом году: {purchasedVehicles.Count()}\n";
            result += $"Списано в этом году: {writtenOffVehicles.Count()}\n\n";

            result += "Поступившие автомобили:\n";
            foreach (var vehicle in purchasedVehicles)
            {
                result += $"- {vehicle.LicensePlate} ({vehicle.PurchaseDate:d})\n";
            }

            ShowMessageBox("11. Поступление/списание", result);
        }

        private void ExecuteQuery12(object parameter)
        {
            string result = "Состав бригады:\n\n";

            var teamLeaders = Employees.Where(e => e.Position == EmployeeType.TeamLeader);
            foreach (var leader in teamLeaders)
            {
                result += $"Бригадир: {leader.LastName} {leader.FirstName}\n";

                var teamMembers = Employees.Where(e => e.SupervisorId == leader.Id);
                foreach (var member in teamMembers)
                {
                    result += $"  - {member.Position}: {member.LastName} {member.FirstName}\n";
                }
                result += "\n";
            }

            ShowMessageBox("12. Состав бригады", result);
        }

        private void ExecuteQuery13(object parameter)
        {
            string result = "Работы специалистов:\n\n";

            var specialists = Employees.Where(e =>
                e.Position == EmployeeType.Welder ||
                e.Position == EmployeeType.Fitter ||
                e.Position == EmployeeType.Assembler ||
                e.Position == EmployeeType.Mechanic);

            foreach (var specialist in specialists)
            {
                result += $"{specialist.Position}: {specialist.LastName} {specialist.FirstName}\n";

                var repairsForSpecialist = Repairs.Where(r => r.EmployeeIds.Contains(specialist.Id));
                result += $"  Выполнено ремонтов: {repairsForSpecialist.Count()}\n\n";
            }

            ShowMessageBox("13. Работы специалистов", result);
        }

        private void ShowMessageBox(string title, string message)
        {
            MessageBox.Show(message, title, MessageBoxButton.OK, MessageBoxImage.Information);
            StatusMessage = $"Выполнен запрос: {title}";
        }
        #endregion
    }
}