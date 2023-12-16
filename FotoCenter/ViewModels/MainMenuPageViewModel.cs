using Core.Command;
using Domain.Models;
using Domain.Notify;
using Domain.Types;
using System.Windows.Input;

namespace FotoCenter.ViewModels
{
    public class MainMenuPageViewModel : NotifyPropertyChangedObject
    {
        public MainMenuPageViewModel() 
        {
            User = MainViewModel.CurrentUser;
            ExitCommand = new RelayCommand(OnExitCommandExecute, CanExitCommandExecute);
            GoToClientsCommand = new RelayCommand(OnGoToClientsCommandExecuted, CanGoToClientsCommandExecute);
            GoToEmployeesCommand = new RelayCommand(OnGoToEmployeesCommandExecuted, CanGoToEmployeesCommandExecute);
            GoToServiceCommand = new RelayCommand(OnGoToServiceCommandExecuted, CanGoToServiceCommandExecute);
            GoToProvisionOfServicesCommand = new RelayCommand(OnGoToProvisionOfServicesCommandExecuted, CanGoToProvisionOfServicesCommandExecute);
        }

        public User User { get; set; }

        public ICommand ExitCommand { get; set; }

        private bool CanExitCommandExecute(object param)
        {
            return true;
        }

        private void OnExitCommandExecute(object param)
        {
            MainViewModel.CloseSession();
        }

        #region NavigationCommands

        public ICommand GoToClientsCommand { get; private set; }

        private bool CanGoToClientsCommandExecute(object parameter)
        {
            return true;
        }

        private void OnGoToClientsCommandExecuted(object parameter)
        {
            MainMenuViewModel.SwitchPage(MainMenuPages.ClientsPage);
        }

        public ICommand GoToEmployeesCommand { get; private set; }

        private bool CanGoToEmployeesCommandExecute(object parameter)
        {
            return true;
        }

        private void OnGoToEmployeesCommandExecuted(object parameter)
        {
            MainMenuViewModel.SwitchPage(MainMenuPages.EmployeesPage);
        }

        public ICommand GoToServiceCommand { get; private set; }

        private bool CanGoToServiceCommandExecute(object parameter)
        {
            return true;
        }

        private void OnGoToServiceCommandExecuted(object parameter)
        {
            MainMenuViewModel.SwitchPage(MainMenuPages.ServicesPage);
        }

        public ICommand GoToProvisionOfServicesCommand { get; private set; }

        private bool CanGoToProvisionOfServicesCommandExecute(object parameter)
        {
            return true;
        }

        private void OnGoToProvisionOfServicesCommandExecuted(object parameter)
        {
            MainMenuViewModel.SwitchPage(MainMenuPages.ProvisionOfServicesPage);
        }

        #endregion
    }
}
