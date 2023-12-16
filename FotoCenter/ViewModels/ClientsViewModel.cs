using Core.Command;
using Domain.Notify;
using Domain.Repositories;
using Domain.Types;
using System.Windows.Input;
using Infrastructure.Repositories;
using Domain.Models;
using System.Collections.ObjectModel;
using FotoCenter.Views.Windows.CreateClientWindow;

namespace FotoCenter.ViewModels
{
    public class ClientsViewModel : NotifyPropertyChangedObject
    {
        private readonly IClientRepository _repository;
        private string _searchLastname;
        public ObservableCollection<Client> _clients;
        private Client _selectedClient;    
        public ClientsViewModel()
        {
            GoBackCommand = new RelayCommand(OnGoBackCommandExecuted, CanGoBackCommandExecute);
            _repository = new ClientRepositoryImpl(new AppContext());
            Haiti = new RelayCommand(OnHaitiExecute, HaititExecute);
            DeleteCommand = new RelayCommand(OnDeleteCommandExecuted, CanDeleteCommandExecute);
            OpenCreateClientWindowCommand = new RelayCommand(OnOpenCreateClientWindowCommandExecuted, CanOpenCreateClientWindowCommandExecute);
            LoadData();
        }
        
        public Client SelectedItem { get; set; }
        
        public Client SelectedClient
        {
            get { return _selectedClient; }
            set { Set(ref _selectedClient, value); }
        }

        public string SearchLastname 
        { 
            get { return _searchLastname; } 
            set { Set(ref _searchLastname, value); }
        }
        public ObservableCollection<Client> Clients 
        {
            get { return _clients; }
            set { Set(ref _clients , value); }
        }
        
        public async void LoadData()
        {
            Clients = new ObservableCollection<Client>(await _repository.GetItemListAsync());
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
                Clients = new ObservableCollection<Client>(await _repository.GetItemListAsync());
                return;
            }
            var dbClients =  await _repository.GetItemListAsync();
            Clients = new ObservableCollection<Client>(dbClients.FindAll(client => client.Lastname.Contains(SearchLastname)));
        }


        public ICommand DeleteCommand { get; private set; }

        private bool CanDeleteCommandExecute(object parameter)
        {
            return SelectedClient != null;
        }

        private async void OnDeleteCommandExecuted(object parameter)
        {

            _repository.RemoveItem(SelectedClient);
            await _repository.SaveAsync();
            Clients.Remove(SelectedClient);
        }

        public ICommand OpenCreateClientWindowCommand { get; private set; }
 
        private bool CanOpenCreateClientWindowCommandExecute(object parameter)
        {
            return true;
        }

        private void OnOpenCreateClientWindowCommandExecuted(object parameter)
        {
            CreateClientWindow createClientWindow = new CreateClientWindow();
            createClientWindow.ShowDialog();
        }


    }
}
