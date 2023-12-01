using Core.Command;
using Domain.Notify;
using Domain.Types;
using Infrastructure.Repositories;
using System.Windows.Input;
using Domain.Models;
using System.Collections.ObjectModel;



namespace FotoCenter.ViewModels
{
    public class OrdersViewModel : NotifyPropertyChangedObject
    {
        private readonly OrdesRepositoryImpl _repository;
        public OrdersViewModel()
        {
            GoBackCommand = new RelayCommand(OnGoBackCommandExecuted, CanGoBackCommandExecute);
            _repository = new OrdesRepositoryImpl(new AppContext());
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
    }
}
