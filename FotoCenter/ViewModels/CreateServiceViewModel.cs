using Core.Command;
using DocumentFormat.OpenXml.Office2010.CustomUI;
using DocumentFormat.OpenXml.Office2016.Drawing.ChartDrawing;
using Domain.Models;
using Domain.Notify;
using Domain.Repositories;
using FotoCenter.Views.Windows.CreateServiceWindow;
using Infrastructure.Repositories;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace FotoCenter.ViewModels
{
    public class CreateServiceViewModel : NotifyPropertyChangedObject
    {
        private Service _service;
        private ObservableCollection<Category> _categories;
        private readonly IServiceRepository _serviceRepository;
        private readonly IUserrRepository _userRepository;
        

        public CreateServiceViewModel()
        {
            Service = new Service();
            User = MainViewModel.CurrentUser;
            _serviceRepository = new ServiceRepositoryImpl(new AppContext());
            _userRepository = new UserrRepositoryImpl(new AppContext());
            _categoryRepository = new CategoryRepositoryImpl(new AppContext());
            CreateCommand = new RelayCommand(OnCreateCommandExecuted, CanCreateCommandExecute);
            LoadData();
        }

        public User User { get; set; }
        public Category Category { get; set; }
        public Category SelectedCategory { get; set; }

        public async void LoadData()
        {
            Categories = new ObservableCollection<Category>(await _categoryRepository.GetItemListAsync());
        }

        private readonly CategoryRepositoryImpl _categoryRepository;

        public ObservableCollection<Category> Categories
        {
            get { return _categories; }
            set { Set(ref _categories, value); }
        }


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
            
            Service.CategoryId = SelectedCategory.Id;
            
            _serviceRepository.CreateItem(Service);
            await _serviceRepository.SaveAsync();

            MessageBox.Show("Успешно");
            (parameter as CreateServiceWindow).Close();
        }
    }
}

