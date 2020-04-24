using FilmManagment.GUI.Commands;
using FilmManagment.GUI.ViewModels.Interfaces;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace FilmManagment.GUI.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public MainViewModel(IHomeViewModel homeViewModel,
                             IFilmListViewModel filmListViewModel,
                             IActorListViewModel actorListViewModel,
                             IDirectorListViewModel directorListViewModel)
        {
            HomeViewModel = homeViewModel;
            FilmListViewModel = filmListViewModel;
            ActorListViewModel = actorListViewModel;
            DirectorListViewModel = directorListViewModel;

            HomeButtonCommand = new RelayCommand(OnHomeButtonCommandExecute);
            FilmsButtonCommand = new RelayCommand(OnFilmsButtonCommandExecute);
            ActorsButtonCommand = new RelayCommand(OnActorsButtonCommandExecute);
            DirectorsButtonCommand = new RelayCommand(OnDirectorsButtonCommandExecute);

            selectedView = HomeViewModel;
        }

        private IViewModel selectedView;
        public IViewModel SelectedView
        {
            get { return selectedView; }
            set
            {
                selectedView = value;
                OnPropertyChanged(nameof(SelectedView));
            }
        }

        // Commands for buttons
        public ICommand HomeButtonCommand { get; }
        public ICommand FilmsButtonCommand { get; }
        public ICommand ActorsButtonCommand { get; }
        public ICommand DirectorsButtonCommand { get; }

        // ViewModels
        public IHomeViewModel HomeViewModel { get; }
        public IFilmListViewModel FilmListViewModel { get; }
        public IActorListViewModel ActorListViewModel { get;  }
        public IDirectorListViewModel DirectorListViewModel { get;  }

        #region Button actions to execute

        private void OnHomeButtonCommandExecute(object parameter)
        {
            if (parameter is MainViewModel)
            {
                SelectedView = HomeViewModel;
            }
        }

        private void OnFilmsButtonCommandExecute(object parameter)
        {
            if (parameter is MainViewModel)
            {
                SelectedView = FilmListViewModel;
            }
        }

        private void OnActorsButtonCommandExecute(object parameter)
        {
            if (parameter is MainViewModel)
            {
                SelectedView = ActorListViewModel;
            }
        }

        private void OnDirectorsButtonCommandExecute(object parameter)
        {
            if (parameter is MainViewModel)
            {
                SelectedView = DirectorListViewModel;
            }
        }

        #endregion
    }
}
