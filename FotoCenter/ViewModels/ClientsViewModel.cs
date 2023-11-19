﻿using Core.Command;
using Domain.Notify;
using Domain.Types;
using System.Windows.Input;

namespace FotoCenter.ViewModels
{
    public class ClientsViewModel : NotifyPropertyChangedObject
    {
        public ClientsViewModel()
        {
            GoBackCommand = new RelayCommand(OnGoBackCommandExecuted, CanGoBackCommandExecute);
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
