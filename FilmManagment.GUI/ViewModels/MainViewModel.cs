using FilmManagment.GUI.Commands;
using FilmManagment.GUI.Services;
using FilmManagment.GUI.ViewModels.Interfaces;
using System.Collections.ObjectModel;
using System.Windows.Input;
using FilmManagment.GUI.Messages;
using FilmManagment.GUI.Wrappers;

namespace FilmManagment.GUI.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private readonly IMediator usedMediator;

        public MainViewModel(IHomeViewModel homeViewModel,
                             IFilmListViewModel filmListViewModel,
                             IActorListViewModel actorListViewModel,
                             IDirectorListViewModel directorListViewModel,
                             IFilmDetailViewModel filmDetailViewModel,
                             IActorDetailViewModel actorDetailViewModel,
                             IDirectorDetailViewModel directorDetailViewModel,
                             IMediator mediator)
        {
            HomeViewModel = homeViewModel;
            FilmListViewModel = filmListViewModel;
            ActorListViewModel = actorListViewModel;
            DirectorListViewModel = directorListViewModel;
            FilmDetailViewModel = filmDetailViewModel;
            ActorDetailViewModel = actorDetailViewModel;
            DirectorDetailViewModel = directorDetailViewModel;

            HomeButtonCommand = new RelayCommand(OnHomeButtonCommandExecute);
            FilmsButtonCommand = new RelayCommand(OnFilmsButtonCommandExecute);
            ActorsButtonCommand = new RelayCommand(OnActorsButtonCommandExecute);
            DirectorsButtonCommand = new RelayCommand(OnDirectorsButtonCommandExecute);

            mediator.Register<DetailButtonPushedMessage<FilmWrappedModel>>(OnFilmDetailExecute);
            mediator.Register<DetailButtonPushedMessage<ActorWrappedModel>>(OnActorDetailExecute);
            mediator.Register<DetailButtonPushedMessage<DirectorWrappedModel>>(OnDirectorDetailExecute);

            mediator.Register<NewMessage<FilmWrappedModel>>(AddNewFilm);
            mediator.Register<NewMessage<ActorWrappedModel>>(AddNewActor);
            mediator.Register<NewMessage<DirectorWrappedModel>>(AddNewDirector);

            mediator.Register<MoveFromDetailToDetail<FilmActorWrappedModel>>(MoveToFilmFromActor);
            mediator.Register<MoveFromDetailToDetail<FilmDirectorWrappedModel>>(MoveToFilmFromDirector);

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
        public IFilmDetailViewModel FilmDetailViewModel { get; }
        public IActorDetailViewModel ActorDetailViewModel { get; }
        public IDirectorDetailViewModel DirectorDetailViewModel { get; }

        #region MainWindow button actions to execute

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

        #region ListViews DetailButton actions to execute

        private void OnFilmDetailExecute(DetailButtonPushedMessage<FilmWrappedModel> _) => SelectedView = FilmDetailViewModel;

        public void OnActorDetailExecute(DetailButtonPushedMessage<ActorWrappedModel> _) => SelectedView = ActorDetailViewModel;

        public void OnDirectorDetailExecute(DetailButtonPushedMessage<DirectorWrappedModel> _) => SelectedView = DirectorDetailViewModel;

        #endregion

        #region ListViews AddButton actions to execute

        private void AddNewFilm(NewMessage<FilmWrappedModel> _) => SelectedView = FilmDetailViewModel;

        private void AddNewActor(NewMessage<ActorWrappedModel> _) => SelectedView = ActorDetailViewModel;

        private void AddNewDirector(NewMessage<DirectorWrappedModel> _) => SelectedView = DirectorDetailViewModel;

        #endregion

        #region Move from detail to detail

        private void MoveToFilmFromActor(MoveFromDetailToDetail<FilmActorWrappedModel> _) => SelectedView = FilmDetailViewModel;

        private void MoveToFilmFromDirector(MoveFromDetailToDetail<FilmDirectorWrappedModel> _) => SelectedView = FilmDetailViewModel;

        #endregion
    }
}
