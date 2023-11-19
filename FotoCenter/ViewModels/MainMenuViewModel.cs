using Domain.Models;
using Domain.Types;
using FotoCenter.Views.Windows.MainMenuWindow.Pages;
using System.ComponentModel;
using System;
using System.Windows.Controls;
using System.Runtime.CompilerServices;

namespace FotoCenter.ViewModels
{
    public class MainMenuViewModel
    {
        public static event EventHandler<PropertyChangedEventArgs> StaticPropertyChanged;

        private static Page _selectedPage;
        private static ClientsPage _clientsPage;
        private static EmployeesPage _employeesPage;
        private static ServicePage _servicePage;
        private static MainMenuPage _mainMenuPage;
        private static OrdersPage _ordersPage;

        public MainMenuViewModel()
        {
            SwitchPage(MainMenuPages.MainMenuPage);
        }

        public User User { get; set; }

        public static Page SelectedPage
        {
            get { return _selectedPage; }
            set { Set(ref _selectedPage, value); }
        }

        public static void SwitchPage(MainMenuPages mainMenuPage)
        {
            switch (mainMenuPage)
            {
                case MainMenuPages.MainMenuPage:
                    if (_mainMenuPage == null)
                        _mainMenuPage = new MainMenuPage();
                    SelectedPage = _mainMenuPage;
                    break;
                case MainMenuPages.ClientsPage:
                    if (_clientsPage == null)
                        _clientsPage = new ClientsPage();
                    SelectedPage = _clientsPage;
                    break;
                case MainMenuPages.EmployeesPage:
                    if (_employeesPage == null)
                        _employeesPage = new EmployeesPage();
                    SelectedPage = _employeesPage;
                    break;
                case MainMenuPages.ServicesPage:
                    if (_servicePage == null)
                        _servicePage = new ServicePage();
                    SelectedPage = _servicePage;
                    break;
                case MainMenuPages.OrdersPage:
                    if (_ordersPage == null)
                        _ordersPage = new OrdersPage();
                    SelectedPage = _ordersPage;
                    break;
            }
        }

        public void DestroyPages()
        {
            _selectedPage = null;
            _clientsPage = null;
            _mainMenuPage = null;
            _servicePage = null;
            _employeesPage = null;
        }

        public static void OnPropertyChanged([CallerMemberName] string propetyName = null) => StaticPropertyChanged?.Invoke(null, new PropertyChangedEventArgs(propetyName));

        public static bool Set<T>(ref T field, T value, [CallerMemberName] string propetyName = null)
        {
            if (Equals(field, value))
                return false;
            field = value;
            OnPropertyChanged(propetyName);
            return true;
        }
    }
}
