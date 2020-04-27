using FilmManagment.BL.Models.ListModels;
using FilmManagment.GUI.Services;
using FilmManagment.GUI.Services.WarningMessageService;
using FilmManagment.GUI.Wrappers;
using FilmManagment.GUI.Messages;
using FilmManagment.GUI.ViewModels.Interfaces;
using System.Collections.ObjectModel;
using System.Windows.Input;
using FilmManagment.GUI.Commands;
using FilmManagment.BL.Facades;
using FilmManagment.GUI.Extensions;

namespace FilmManagment.GUI.ViewModels
{
    public class FilmListViewModel : ViewModelBase, IFilmListViewModel
    {
        private readonly IMediator usedMediator;
        private readonly IWarningService usedWarningService;
        private readonly FilmFacade usedFacade;

        public FilmListViewModel(IMediator mediator,
                                 IWarningService warningService,
                                 FilmFacade facade)
        {
            usedMediator = mediator;
            usedWarningService = warningService;
            usedFacade = facade;

            mediator.Register<YES_WarningResultMessage<FilmWrappedModel>>(DeleteFilm);
            mediator.Register<NO_WarningResultMessage<FilmWrappedModel>>(UpdateFilms);

            FilmSelectedCommand = new RelayCommand<FilmListModel>(FilmSelected);
            AddButtonCommand = new RelayCommand(FilmNew);
            DeleteButtonCommand = new RelayCommand(OnDeleteButtonCommandExecute);
            DetailButtonCommand = new RelayCommand(OnDetailButtonCommandExecute);

            Load();
        }

        // Commands
        public ICommand FilmSelectedCommand { get; }
        public ICommand AddButtonCommand { get; }
        public ICommand DeleteButtonCommand { get; }
        public ICommand DetailButtonCommand { get; }
        public ICommand SearchButtonCommand { get; }


        public ObservableCollection<FilmListModel> Films { get; } = new ObservableCollection<FilmListModel>();

        private FilmListModel selectedFilm;

        private void FilmSelected(FilmListModel filmListModel)
        {
            usedMediator.Send(new SelectedMessage<FilmWrappedModel> { Id = filmListModel.Id });
            selectedFilm = filmListModel;
        }

        private void FilmNew() => usedMediator.Send(new NewMessage<FilmWrappedModel>());

        private void OnDetailButtonCommandExecute(object parameter) => usedMediator.Send(new DetailButtonPushedMessage<FilmWrappedModel>());

        private void OnDeleteButtonCommandExecute(object parameter)
        {
            usedWarningService.ShowWarning($"Are you sure ?");
        }

        private void DeleteFilm(YES_WarningResultMessage<FilmWrappedModel> _)
        {
            usedFacade.Delete(selectedFilm.Id);
            Load();
        }

        private void UpdateFilms(NO_WarningResultMessage<FilmWrappedModel> _)
        {

        }

        public void Load()
        {
            Films.Clear();
            var filmsFromDB = usedFacade.GetAllList();
            Films.AddList(filmsFromDB);
        }
    }
}
