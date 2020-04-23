using FilmManagment.GUI.Commands;
using FilmManagment.GUI.ViewModels.Interfaces;
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

            SelectedView = new HomeViewModel();
        }

        public ViewModelBase SelectedView
        {
            get { return SelectedView; }
            set
            {
                // ERROR: System.StackOverflowException
                SelectedView = value;
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

        // Button actions
        private void OnHomeButtonCommandExecute(object parameter)
        {
            if (parameter is IHomeViewModel homeViewModel)
            {
                SelectedView = new HomeViewModel();
            }
        }

        private void OnFilmsButtonCommandExecute(object parameter)
        {
            if (parameter is IFilmListViewModel filmListViewModel)
            {
                //SelectedView = new FilmListViewModel();
            }
        }
    }
}
