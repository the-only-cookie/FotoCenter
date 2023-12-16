using Core.Command;
using DocumentFormat.OpenXml.Office2010.CustomUI;
using Domain.Models;
using Domain.Notify;
using Domain.Repositories;
using FotoCenter.Views.Windows.CreateServiceWindow;
using Infrastructure.Repositories;
using System.Windows;
using System.Windows.Input;

namespace FotoCenter.ViewModels
{
    public class CreateServiceViewModel : NotifyPropertyChangedObject
    {
        private Service _service;
        private readonly IServiceRepository _serviceRepository;
        private readonly IUserrRepository _userRepository;

        public CreateServiceViewModel()
        {
            Service = new Service();
            User = MainViewModel.CurrentUser;
            _serviceRepository = new ServiceRepositoryImpl(new AppContext());
            _userRepository = new UserrRepositoryImpl(new AppContext());
            CreateCommand = new RelayCommand(OnCreateCommandExecuted, CanCreateCommandExecute);
        }

        public User User { get; set; }

        public Service Service
        {
            get { return _service; }
            set { Set(ref _service, value); }
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
            user.Password = Service.Title;
            user.RoleId = 2;
            _userRepository.CreateItem(user);
            await _userRepository.SaveAsync();

            Service.Id = user.Id;
            //Service. = user;
            _serviceRepository.CreateItem(Service);
            await _serviceRepository.SaveAsync();

            MessageBox.Show("Успешно");
            (parameter as CreateServiceWindow).Close();
        }
    }
}

