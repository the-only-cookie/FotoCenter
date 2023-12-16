using Core.Command;
using Domain.Notify;
using Domain.Repositories;
using Domain.Types;
using Infrastructure.Repositories;
using System.Windows.Input;
using Domain.Models;
using System.Collections.ObjectModel;
using DocumentFormat.OpenXml.Office2016.Drawing.ChartDrawing;
using FotoCenter.Views.Windows.CreateProvisionOfServicesWindow;
using FotoCenter.Views.Windows.CreateServiceWindow;

namespace FotoCenter.ViewModels

{
    
    public class ServiceViewModel : NotifyPropertyChangedObject
    {
        private readonly ServiceRepositoryImpl _repository;
        private string _searchTitle;
        public ObservableCollection<Service> _services;
        private Service _selectedService;
        public ServiceViewModel() 
        {
            User = MainViewModel.CurrentUser;
            GoBackCommand = new RelayCommand(OnGoBackCommandExecuted, CanGoBackCommandExecute);
            _repository = new ServiceRepositoryImpl(new AppContext());
            Haiti = new RelayCommand(OnHaitiExecute, HaititExecute);
            DeleteCommand = new RelayCommand(OnDeleteCommandExecuted, CanDeleteCommandExecute);
            OpenCreateServiceWindowCommand = new RelayCommand(OnOpenCreateServiceWindowCommandExecuted, CanOpenCreateServiceWindowCommandExecute);
            LoadData();
        }
        public Service SelectedItem { get; set; }

        public User User { get; set; }
        public Service SelectedService
        {
            get { return _selectedService; }
            set { Set(ref _selectedService, value); }
        }

        public string SearchTitle
        {
            get { return _searchTitle; }
            set { Set(ref _searchTitle, value); }
        }
        public async void LoadData()
        {
            Services = new ObservableCollection<Service>(await _repository.GetItemListAsync());
        }

        public ObservableCollection<Service> Services
        {
            get { return _services; }
            set { Set(ref _services, value); }
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
            if (string.IsNullOrWhiteSpace(SearchTitle))
            {
                Services = new ObservableCollection<Service>(await _repository.GetItemListAsync());
                return;
            }
            var dbServices = await _repository.GetItemListAsync();
            Services = new ObservableCollection<Service>(dbServices.FindAll(service => service.Title.Contains(SearchTitle)));
        }


        public ICommand DeleteCommand { get; private set; }

        private bool CanDeleteCommandExecute(object parameter)
        {
            return SelectedService != null;
        }

        private async void OnDeleteCommandExecuted(object parameter)
        {

            _repository.RemoveItem(SelectedService);
            await _repository.SaveAsync();
            Services.Remove(SelectedService);
        }
        public ICommand OpenCreateServiceWindowCommand { get; private set; }

        private bool CanOpenCreateServiceWindowCommandExecute(object parameter)
        {
            return true;
        }

        private void OnOpenCreateServiceWindowCommandExecuted(object parameter)
        {
            CreateServiceWindow createServiceWindow = new CreateServiceWindow();
            createServiceWindow.ShowDialog();
        }
    }
}
