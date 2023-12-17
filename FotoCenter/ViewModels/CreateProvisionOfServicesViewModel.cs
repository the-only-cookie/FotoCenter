using Core.Command;
using DocumentFormat.OpenXml.Office2010.CustomUI;
using DocumentFormat.OpenXml.Office2010.Excel;
using Domain.Models;
using Domain.Notify;
using Domain.Repositories;
using FotoCenter.Views.Windows.CreateProvisionOfServicesWindow;
using Infrastructure.Repositories;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace FotoCenter.ViewModels
{
    public class CreateProvisionOfServicesViewModel : NotifyPropertyChangedObject
    {
        private ProvisionOfServices _provisionOfServices;
        
        private ProvisionOfServices Id;
        public ObservableCollection<Service> _services;
        public ObservableCollection<Employee> _employees;
        public ObservableCollection<Client> _clients;
        private readonly IProvisionOfServicesRepository _provisionOfServicesRepository;
        
        

        public CreateProvisionOfServicesViewModel()
        {
            ProvisionOfServices = new ProvisionOfServices();
            User = MainViewModel.CurrentUser;
            _provisionOfServicesRepository = new ProvisionOfServicesRepositoryImpl(new Domain.Models.AppContext());
            _clientRepository = new ClientRepositoryImpl(new Domain.Models.AppContext());
            _employeeRepository = new EmployeeRepositoryImpl(new Domain.Models.AppContext());
            _serviceRepository = new ServiceRepositoryImpl(new Domain.Models.AppContext());
            CreateCommand = new RelayCommand(OnCreateCommandExecuted, CanCreateCommandExecute);
            LoadData();
        }

        public User User { get; set; }
       

        private readonly ClientRepositoryImpl _clientRepository;
        public Service SelectedService { get; set; }
        public Client SelectedClient { get; set; }
        public Employee SelectedEmployee { get; set; }

        public ObservableCollection<Client> Clients
        {
            get { return _clients; }
            set { Set(ref _clients, value); }
        }

        public ProvisionOfServices ProvisionOfServices
        {
            get { return _provisionOfServices; }
            set { Set(ref _provisionOfServices, value); }

        }
        private readonly EmployeeRepositoryImpl _employeeRepository;

        public ObservableCollection<Employee> Employees
        {
            get { return _employees; }
            set { Set(ref _employees, value); }
        }
       
        private readonly ServiceRepositoryImpl _serviceRepository;
        
        public ObservableCollection<Service> Services
        {
            get { return _services; }
            set { Set(ref _services, value); }
        }
        public async void LoadData()
        {
            Services = new ObservableCollection<Service>(await _serviceRepository.GetItemListAsync());
            Employees = new ObservableCollection<Employee>(await _employeeRepository.GetItemListAsync());
            Clients = new ObservableCollection<Client>(await _clientRepository.GetItemListAsync());
        }
        public Service Service { get; set; }


        public ICommand CreateCommand { get; set; }

        public bool CanCreateCommandExecute(object parameter)
        {
            return true;
        }

        public async void OnCreateCommandExecuted(object parameter)
        {

            //Service.Id = new Service.Id();
            ProvisionOfServices.ServiceId = SelectedService.Id;
            ProvisionOfServices.ClientId = SelectedClient.Id;
            ProvisionOfServices.EmployeeId = SelectedEmployee.Id;
            ProvisionOfServices.DateOfProvisionOfServices = DateTime.Now;
            _provisionOfServicesRepository.CreateItem(ProvisionOfServices);
            await _provisionOfServicesRepository.SaveAsync();

            MessageBox.Show("Успешно");
            (parameter as CreateProvisionOfServicesWindow).Close();
        }
    }
}

