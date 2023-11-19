using FotoCenter.ViewModels;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace FotoCenter.Views.Windows.MainMenuWindow
{
    /// <summary>
    /// Логика взаимодействия для MainMenuWindow.xaml
    /// </summary>
    public partial class MainMenuWindow : Window
    {
        public MainMenuWindow()
        {
            InitializeComponent();
        }

        private void Frame_Navigating(object sender, NavigatingCancelEventArgs e)
        {
            if (e.NavigationMode != NavigationMode.New)
                e.Cancel = true;

            FrameworkElement content = e.Content as FrameworkElement;
            if (content != null && content.DataContext == null)
                content.DataContext = (sender as Frame).DataContext;
        }

        private void Window_Closed(object sender, System.EventArgs e)
        {
            (DataContext as MainMenuViewModel).DestroyPages();
        }
    }
}
