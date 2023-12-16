using Core.Command;
using Domain.Notify;
using Domain.Repositories;
using Domain.Types;
using Infrastructure.Repositories;
using System.Windows.Input;
using Domain.Models;
using System.Collections.ObjectModel;
using FotoCenter.Views.Windows.CreateClientWindow;
using FotoCenter.Views.Windows.CreateEmployeeWindow;

namespace FotoCenter.ViewModels
{
    public class EmployeeViewModel : NotifyPropertyChangedObject
    {
        private readonly EmployeeRepositoryImpl _repository;
        private string _searchLastname;
        public ObservableCollection<Employee> _employees;
        private Employee _selectedEmployee;

        public EmployeeViewModel() 
        {
            GoBackCommand = new RelayCommand(OnGoBackCommandExecuted, CanGoBackCommandExecute);
            _repository = new EmployeeRepositoryImpl(new AppContext());
            Haiti = new RelayCommand(OnHaitiExecute, HaititExecute);
            DeleteCommand = new RelayCommand(OnDeleteCommandExecuted, CanDeleteCommandExecute);
            OpenCreateEmployeeWindowCommand = new RelayCommand(OnOpenCreateEmployeeWindowCommandExecuted, CanOpenCreateEmployeeWindowCommandExecute);
            LoadData();
        }
        public Employee SelectedItem { get; set; }

        public Employee SelectedEmployee
        {
            get { return _selectedEmployee; }
            set { Set(ref _selectedEmployee, value); }
        }

        public string SearchLastname
        {
            get { return _searchLastname; }
            set { Set(ref _searchLastname, value); }
        }
        public ObservableCollection<Employee> Employees
        {
            get { return _employees; }
            set { Set(ref _employees, value); }
        }

        public async void LoadData()
        {
            Employees = new ObservableCollection<Employee>(await _repository.GetItemListAsync());
        }

       

        public ICommand GoBackCommand { get; set; }

        public bool CanGoBackCommandExecute(object parameter)
        {
            return true;
        }

        public void OnGoBackCommandExecuted(object parameter)
        {
            MainMenuViewModel.SwitchPage(MainMenuPages.MainMenuPage);
        }
        public ICommand Haiti { get; private set; }

        private bool HaititExecute(object parameter)
        {
            return true;
        }

        private async void OnHaitiExecute(object parameter)
        {
            if (string.IsNullOrWhiteSpace(SearchLastname))
            {
                Employees = new ObservableCollection<Employee>(await _repository.GetItemListAsync());
                return;
            }
            var dbEmployees = await _repository.GetItemListAsync();
            Employees = new ObservableCollection<Employee>(dbEmployees.FindAll(employee => employee.Lastname.Contains(SearchLastname)));
        }


        public ICommand DeleteCommand { get; private set; }

        private bool CanDeleteCommandExecute(object parameter)
        {
            return SelectedEmployee != null;
        }

        private async void OnDeleteCommandExecuted(object parameter)
        {

            _repository.RemoveItem(SelectedEmployee);
            await _repository.SaveAsync();
            Employees.Remove(SelectedEmployee);
        }
        public ICommand OpenCreateEmployeeWindowCommand { get; private set; }

        private bool CanOpenCreateEmployeeWindowCommandExecute(object parameter)
        {
            return true;
        }

        private void OnOpenCreateEmployeeWindowCommandExecuted(object parameter)
        {
            CreateEmployeeWindow createEmployeeWindow = new CreateEmployeeWindow();
            createEmployeeWindow.ShowDialog();
        }
    }
}

