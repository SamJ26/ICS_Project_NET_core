using FilmManagment.GUI.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace FilmManagment.GUI.ViewModels
{
    public class MainViewModel : ViewModelBase
    {

        public MainViewModel()
        {
            //ActorsButtonCommand = new RelayCommand()
        }

        public ViewModelBase selectedView
        {
            get { return selectedView; }
            set
            {
                selectedView = value;
                OnPropertyChanged(nameof(selectedView));
            }
        }

        // Commands for buttons
        public ICommand SearchButtonCommand { get; }
        public ICommand ActorsButtonCommand { get; }
        public ICommand FilmsButtonCommand { get; }
        public ICommand DirectorsButtonCommand { get; }

        private void OnActorsButtonCommandExecute(object parameter)
        {

        }
    }
}
