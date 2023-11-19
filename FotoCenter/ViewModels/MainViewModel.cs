using Core.Command;
using Domain.Models;
using Domain.Repositories;
using FotoCenter.Views.Windows.MainMenuWindow;
using Infrastructure.Repositories;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace FotoCenter.ViewModels
{
    public class MainViewModel
    {
        private readonly IUserrRepository _userrRepository;
        public MainViewModel()
        {
            _userrRepository = new UserrRepositoryImpl(new AppContext());
            AuthCommand = new RelayCommand(OnAuthCommandExecutedAsync, CanAuthCommandExecute);
            GuestAuthCommand = new RelayCommand(OnGuestAuthCommandExecuted, CanGuestAuthCommandExecute);
        }

        public static User CurrentUser { get; private set; }
        public string Password { get; set; }
        public string Login { get; set; }
        public static MainMenuWindow MainMenuWindow { get; set; }

        public ICommand AuthCommand { get; set; }
        private bool CanAuthCommandExecute(object parameter)
        {
            return !string.IsNullOrWhiteSpace(Login) && !string.IsNullOrWhiteSpace(Password);
        }
        
        private async void OnAuthCommandExecutedAsync(object parameter)
        {
            CurrentUser = await CheckUserAsync();
            if (CurrentUser == null)
            {
                MessageBox.Show("Неверный логин или пароль", "Ошибка");
                return;
            }
            MainWindow window = parameter as MainWindow;
            window.Hide();
            MainMenuWindow = new MainMenuWindow();
            MainMenuWindow.ShowDialog();
            window.Show();
        }

        public ICommand GuestAuthCommand { get; set; }
        private bool CanGuestAuthCommandExecute(object parameter)
        {
            return true;
        }

        private void OnGuestAuthCommandExecuted(object parameter)
        {
            CurrentUser = new User()
            {
                Login = "Гость",
                Role = new Role() { Title = "Гость" }
            };
            MainWindow window = parameter as MainWindow;
            window.Hide();
            MainMenuWindow = new MainMenuWindow();
            MainMenuWindow.ShowDialog();
            window.Show();
        }

        private async Task<User> CheckUserAsync()
        {
            User userr = await _userrRepository.GetUserrByLoginAsync(Login);
            return userr?.Password == Password ? userr : null;
        }

        public static void CloseSession()
        {
            CurrentUser = null;
            MainMenuWindow.Close();
        }
    }
}
