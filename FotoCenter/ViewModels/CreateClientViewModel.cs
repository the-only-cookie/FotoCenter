using Core.Command;
using DocumentFormat.OpenXml.Office2010.CustomUI;
using Domain.Models;
using Domain.Notify;
using Domain.Repositories;
using FotoCenter.Views.Windows.CreateClientWindow;
using Infrastructure.Repositories;
using System.Windows;
using System.Windows.Input;

namespace FotoCenter.ViewModels
{
    public class CreateClientViewModel : NotifyPropertyChangedObject
    {
        private Client _client;
        private readonly IClientRepository _clientRepository;
        private readonly IUserrRepository _userRepository;

        public CreateClientViewModel()
        {
            Client = new Client();
            User = MainViewModel.CurrentUser;
            _clientRepository = new ClientRepositoryImpl(new AppContext());
            _userRepository = new UserrRepositoryImpl(new AppContext());
            CreateCommand = new RelayCommand(OnCreateCommandExecuted, CanCreateCommandExecute);
        }

        public User User { get; set; }

        public Client Client
        {
            get { return _client; }
            set { Set(ref _client, value); }
        }

        public ICommand CreateCommand { get; set; }

        public bool CanCreateCommandExecute(object parameter)
        {
            return true;
        }

        public async void OnCreateCommandExecuted(object parameter)
        {
            User user = new User();
            user.Login = "Клиент";
            user.Password = Client.PhoneNumber;
            user.RoleId = 3;
            _userRepository.CreateItem(user);
            await _userRepository.SaveAsync();
            
           
            Client.User = user;
            _clientRepository.CreateItem(Client);
            await _clientRepository.SaveAsync();
            
            MessageBox.Show("Успешно");
            (parameter as CreateClientWindow).Close();
        }
    }
}
