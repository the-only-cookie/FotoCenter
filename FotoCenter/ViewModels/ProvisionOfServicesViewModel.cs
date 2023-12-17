using Core.Command;
using Domain.Notify;
using Domain.Repositories;
using Domain.Types;
using System.Windows.Input;
using Infrastructure.Repositories;
using Domain.Models;
using System.Collections.ObjectModel;
using FotoCenter.Views.Windows.CreateProvisionOfServicesWindow;

namespace FotoCenter.ViewModels
{
    public class ProvisionOfServicesViewModel : NotifyPropertyChangedObject
    {
        private readonly IProvisionOfServicesRepository _repository;
        private ObservableCollection<ProvisionOfServices> _provisionOfServices;
        private string _searxhClientLastname;
        private ProvisionOfServices _selectedProvisionOfServices;

        public ProvisionOfServicesViewModel()
        {
            GoBackCommand = new RelayCommand(OnGoBackCommandExecuted, CanGoBackCommandExecute);
            _repository = new ProvisionOfServicesRepositoryImpl(new AppContext());
            Haiti = new RelayCommand(OnHaitiExecute, HaititExecute);
            DeleteCommand = new RelayCommand(OnDeleteCommandExecuted, CanDeleteCommandExecute);
            OpenCreateProvisionOfServicesWindowCommand = new RelayCommand(OnOpenCreateProvisionOfServicesWindowCommandExecuted, CanOpenCreateProvisionOfServicesWindowCommandExecute);
            LoadData();
        }
        public ProvisionOfServices SelectedItem { get; set; }
        public ProvisionOfServices SelectedServices { get; set; }
      

        public ProvisionOfServices SelectedProvisionOfServices
        {
            get { return _selectedProvisionOfServices; }
            set { Set(ref _selectedProvisionOfServices, value); }
        }

        public string SearxhClientLastname
        {
            get { return _searxhClientLastname; }
            set { Set(ref _searxhClientLastname, value); }
        }
        public ObservableCollection<ProvisionOfServices> ProvisionOfServices
        {
            get { return _provisionOfServices; }
            set { Set(ref _provisionOfServices, value); }
        }

        public async void LoadData()
        {
            ProvisionOfServices = new ObservableCollection<ProvisionOfServices>(await _repository.GetItemListAsync());
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
            if (string.IsNullOrWhiteSpace(SearxhClientLastname))
            {
                ProvisionOfServices = new ObservableCollection<ProvisionOfServices>(await _repository.GetItemListAsync());
                return;
            }
            var dbProvisionOfServices = await _repository.GetItemListAsync();
            ProvisionOfServices = new ObservableCollection<ProvisionOfServices>(dbProvisionOfServices.FindAll(provisionOfServices => provisionOfServices.Client.Lastname.Contains(SearxhClientLastname)));
        }


        public ICommand DeleteCommand { get; private set; }

        private bool CanDeleteCommandExecute(object parameter)
        {
            return SelectedProvisionOfServices != null;
        }

        private async void OnDeleteCommandExecuted(object parameter)
        {

            _repository.RemoveItem(SelectedProvisionOfServices);
            await _repository.SaveAsync();
            ProvisionOfServices.Remove(SelectedProvisionOfServices);
        }
        public ICommand OpenCreateProvisionOfServicesWindowCommand { get; private set; }

        private bool CanOpenCreateProvisionOfServicesWindowCommandExecute(object parameter)
        {
            return true;
        }

        private void OnOpenCreateProvisionOfServicesWindowCommandExecuted(object parameter)
        {
            CreateProvisionOfServicesWindow createProvisionOfServicesWindow = new CreateProvisionOfServicesWindow();
            createProvisionOfServicesWindow.ShowDialog();
        }
    }      
}
