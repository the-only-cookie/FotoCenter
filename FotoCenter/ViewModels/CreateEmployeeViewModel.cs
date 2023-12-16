using Core.Command;
using DocumentFormat.OpenXml.Office2010.CustomUI;
using Domain.Models;
using Domain.Notify;
using Domain.Repositories;
using FotoCenter.Views.Windows.CreateEmployeeWindow;
using Infrastructure.Repositories;
using System.Windows;
using System.Windows.Input;

namespace FotoCenter.ViewModels
{
    public class CreateEmployeeViewModel : NotifyPropertyChangedObject
    {
        private Employee _employee;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IUserrRepository _userRepository;
        private readonly IFotocenterRepository _fotocenterRepository;

        public CreateEmployeeViewModel()
        {
            Employee = new Employee();
            User = MainViewModel.CurrentUser;
            _employeeRepository = new EmployeeRepositoryImpl(new AppContext());
            _userRepository = new UserrRepositoryImpl(new AppContext());
            CreateCommand = new RelayCommand(OnCreateCommandExecuted, CanCreateCommandExecute);
        }

        public User User { get; set; }
        public Fotocenter Fotocenter { get; set; }

        public Employee Employee
        {
            get { return _employee; }
            set { Set(ref _employee, value); }
        }

        public ICommand CreateCommand { get; set; }

        public bool CanCreateCommandExecute(object parameter)
        {
            return true;
        }

        public async void OnCreateCommandExecuted(object parameter)
        {
            User user = new User();
            user.Login = "Сотрудник";
            user.Password = Employee.Lastname;
            user.RoleId = 2;
            Employee.FotocenterId = 1;
            Employee.PostId = 4;
            _userRepository.CreateItem(user);
            await _userRepository.SaveAsync();

            Employee.Id = user.Id;
            Employee.User = user;
            _employeeRepository.CreateItem(Employee);
            await _employeeRepository.SaveAsync();

            MessageBox.Show("Успешно");
            (parameter as CreateEmployeeWindow).Close();
        }
    }
}
