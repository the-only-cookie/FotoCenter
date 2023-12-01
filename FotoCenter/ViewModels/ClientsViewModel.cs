using Core.Command;
using Domain.Notify;
using Domain.Repositories;
using Domain.Types;
using System.Windows.Input;
using Infrastructure.Repositories;
using Domain.Models;
using System.Collections.ObjectModel;

namespace FotoCenter.ViewModels
{
    public class ClientsViewModel : NotifyPropertyChangedObject
    {
        private readonly IClientRepository _repository;

        public ClientsViewModel()
        {
            GoBackCommand = new RelayCommand(OnGoBackCommandExecuted, CanGoBackCommandExecute);
            _repository = new ClientRepositoryImpl(new AppContext());
        }

        public Client SelectedItem { get; set; }
        
        public ObservableCollection<Client> Clients { get; set; }

        public ICommand GoBackCommand { get; set; }
        
        public bool CanGoBackCommandExecute(object parameter)
        {
            return true;
        }

        public void OnGoBackCommandExecuted(object parameter)
        {
            MainMenuViewModel.SwitchPage(MainMenuPages.MainMenuPage);
        }
    }
}
