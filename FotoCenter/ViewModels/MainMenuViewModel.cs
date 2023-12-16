using Domain.Models;
using Domain.Types;
using FotoCenter.Views.Windows.MainMenuWindow.Pages;
using System.ComponentModel;
using System;
using System.Windows.Controls;
using System.Runtime.CompilerServices;
using System.Reflection;
using Infrastructure.Repositories;

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
        private static ProvisionOfServicesPage _provisionOfServicesPage;
      

 

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

        private static string _title;
        public static string Title
        {
            get { return _title; }
            set { Set(ref _title, value); }
        }

        public static void SwitchPage(MainMenuPages mainMenuPage)
        {
            switch (mainMenuPage)
            {
                case MainMenuPages.MainMenuPage:
                    if (_mainMenuPage == null)
                        _mainMenuPage = new MainMenuPage();
                    Title = "Главное меню";
                    SelectedPage = _mainMenuPage;
                    break;
                case MainMenuPages.ClientsPage:
                    if (_clientsPage == null)
                        _clientsPage = new ClientsPage();
                    Title = "Клиенты";
                    SelectedPage = _clientsPage;
                    break;
                case MainMenuPages.EmployeesPage:
                    if (_employeesPage == null)
                        _employeesPage = new EmployeesPage();
                    Title = "Сотрудники";
                    SelectedPage = _employeesPage;
                    break;
                case MainMenuPages.ServicesPage:
                    if (_servicePage == null)
                        _servicePage = new ServicePage();
                    Title = "Услуги";
                    SelectedPage = _servicePage;
                    break;
                case MainMenuPages.ProvisionOfServicesPage:
                    if (_provisionOfServicesPage == null)
                        _provisionOfServicesPage = new ProvisionOfServicesPage();
                    Title = "Заказы";
                    SelectedPage = _provisionOfServicesPage;
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
