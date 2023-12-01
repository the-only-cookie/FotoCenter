using Core.Command;
using Domain.Notify;
using Domain.Repositories;
using Domain.Types;
using Infrastructure.Repositories;
using System.Windows.Input;
using Domain.Models;
using System.Collections.ObjectModel;

namespace FotoCenter.ViewModels
{
    public class EmployeeViewModel : NotifyPropertyChangedObject
    {
        private readonly EmployeeRepositoryImpl _repository;

        public EmployeeViewModel() 
        {
            GoBackCommand = new RelayCommand(OnGoBackCommandExecuted, CanGoBackCommandExecute);
            _repository = new EmployeeRepositoryImpl(new AppContext());
        }
        public Employee SelectedItem { get; set; }

        public ObservableCollection<Employee> Employees { get; set; }

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
