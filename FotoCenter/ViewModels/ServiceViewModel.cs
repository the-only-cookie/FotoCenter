using Core.Command;
using Domain.Notify;
using Domain.Types;
using Infrastructure.Repositories;
using System.Windows.Input;
using Domain.Models;
using System.Collections.ObjectModel;

namespace FotoCenter.ViewModels

{
    public class ServiceViewModel : NotifyPropertyChangedObject
    {
        private readonly ServiceRepositoryImpl _repository;
        public ServiceViewModel() 
        {
            GoBackCommand = new RelayCommand(OnGoBackCommandExecuted, CanGoBackCommandExecute);
            _repository = new ServiceRepositoryImpl(new AppContext());
        }
        public Service SelectedItem { get; set; }

        public ObservableCollection<Service> Service { get; set; }

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
