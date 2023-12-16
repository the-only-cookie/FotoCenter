using Core.Command;
using DocumentFormat.OpenXml.Office2010.CustomUI;
using Domain.Models;
using Domain.Notify;
using Domain.Repositories;
using FotoCenter.Views.Windows.CreateProvisionOfServicesWindow;
using Infrastructure.Repositories;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace FotoCenter.ViewModels
{
    public class CreateProvisionOfServicesViewModel : NotifyPropertyChangedObject
    {
        private ProvisionOfServices _provisionOfServices;
        private ObservableCollection<Category> _categories;
        private readonly IProvisionOfServicesRepository _provisionOfServicesRepository;
        private readonly IUserrRepository _userRepository;
        public ProvisionOfServices SelectedCategory { get; set; }

        public CreateProvisionOfServicesViewModel()
        {
            ProvisionOfServices = new ProvisionOfServices();
            User = MainViewModel.CurrentUser;
            _provisionOfServicesRepository = new ProvisionOfServicesRepositoryImpl(new AppContext());
            _userRepository = new UserrRepositoryImpl(new AppContext());
           CreateCommand = new RelayCommand(OnCreateCommandExecuted, CanCreateCommandExecute);
            LoadData();
        }

        public User User { get; set; }

        public ProvisionOfServices ProvisionOfServices
        {
            get { return _provisionOfServices; }
            set { Set(ref _provisionOfServices, value); }

        }
        private readonly CategoryRepositoryImpl _categoryRepository;
        public ObservableCollection<Category> Categories
        {
            get { return _categories; }
            set { Set(ref _categories, value); }
        }
        public async void LoadData()
        {
            Categories = new ObservableCollection<Category>(await _categoryRepository.GetItemListAsync());
        }

        public ICommand CreateCommand { get; set; }

        public bool CanCreateCommandExecute(object parameter)
        {
            return true;
        }

        public async void OnCreateCommandExecuted(object parameter)
        {
            ProvisionOfServices order = new ProvisionOfServices();
            //new ProvisionOfServices.CategoryId = SelectedCategoryId;
            //ProvisionOfServices.CategoryId = Category.Id;
            _provisionOfServicesRepository.CreateItem(ProvisionOfServices);
            await _provisionOfServicesRepository.SaveAsync();

            MessageBox.Show("Успешно");
            (parameter as CreateProvisionOfServicesWindow).Close();
        }
    }
}

