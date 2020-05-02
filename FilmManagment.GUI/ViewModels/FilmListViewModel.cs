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
using System.Linq;
using System.Collections.Generic;

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
            mediator.Register<UpdateMessage<FilmWrappedModel>>(UpdateFilms);

            FilmSelectedCommand = new RelayCommand<FilmListModel>(OnFilmSelectedCommandExecute);
            AddButtonCommand = new RelayCommand(OnAddButtonCommandExecute);
            DeleteButtonCommand = new RelayCommand(OnDeleteButtonCommandExecute, IsEnabled_DeleteButton);
            DetailButtonCommand = new RelayCommand(OnDetailButtonCommandExecute, IsEnabled_DetailButton);
            RefreshButtonCommand = new RelayCommand(OnRefreshButtonCommandExecute);
            SearchButtonCommand = new RelayCommand(OnSearchButtonCommandExecute);

            SearchedObject = "What are you looking for?";
            SearchingOptions = new List<string>() { "Origninal name", "Czech name", "Country of origin" };
            SelectedOption = SearchingOptions[0];

            Load();
        }

        // Commands
        public ICommand FilmSelectedCommand { get; }
        public ICommand AddButtonCommand { get; }
        public ICommand DeleteButtonCommand { get; }
        public ICommand DetailButtonCommand { get; }
        public ICommand RefreshButtonCommand { get; }
        public ICommand SearchButtonCommand { get; }


        public ObservableCollection<FilmListModel> Films { get; set; } = new ObservableCollection<FilmListModel>();
        public string SearchedObject { get; set; }
        public List<string> SearchingOptions { get; set; }
        public string SelectedOption { get; set; }


        private FilmListModel selectedFilm;

        private ICollection<FilmListModel> foundFilms;


        #region Actions triggered by RelayCommand

        private void OnFilmSelectedCommandExecute(FilmListModel filmListModel)
        {
            usedMediator.Send(new SelectedMessage<FilmWrappedModel> { Id = filmListModel.Id });
            selectedFilm = filmListModel;
        }

        private void OnAddButtonCommandExecute()
        {
            selectedFilm = null;
            usedMediator.Send(new NewMessage<FilmWrappedModel>());
        }

        private void OnDeleteButtonCommandExecute() => usedWarningService.ShowWarning(typeof(FilmWrappedModel));

        private void OnDetailButtonCommandExecute()
        {
            selectedFilm = null;
            usedMediator.Send(new DetailButtonPushedMessage<FilmWrappedModel>());
        }

        private void OnRefreshButtonCommandExecute()
        {
            selectedFilm = null;
            Load();
        } 

        private void OnSearchButtonCommandExecute()
        {
            selectedFilm = null;
            if ( !string.IsNullOrEmpty(SearchedObject) && !string.IsNullOrWhiteSpace(SearchedObject))
            {
                foundFilms = Search();
                Films.Clear();
                Films.AddList(foundFilms);
            }
        }

        #endregion

        private bool IsEnabled_DeleteButton() => selectedFilm == null ? false : true;

        private bool IsEnabled_DetailButton() => selectedFilm == null ? false : true;

        private void DeleteFilm(YES_WarningResultMessage<FilmWrappedModel> _)
        {
            usedFacade.Delete(selectedFilm.Id);
            selectedFilm = null;
            Load();
        }

        private void UpdateFilms(IMessage _)
        {
            selectedFilm = null;
            Load();
        }   

        public void Load()
        {
            Films.Clear();
            var filmsFromDB = usedFacade.GetAllList();
            Films.AddList(filmsFromDB);
        }

        private ICollection<FilmListModel> Search()
        {
            var query = usedFacade.GetAllList();

            // Searching according to Czech name
            if (SelectedOption == SearchingOptions.ElementAt(1))
                return query.Where(film => film.CzechName == SearchedObject).ToList();

            // Searching according to Country of origin
            else if(SelectedOption == SearchingOptions.ElementAt(2))
                return query.Where(film => film.CountryOfOrigin == SearchedObject).ToList();

            // Default: Searching according to Original name
            else
                return query.Where(film => film.OriginalName == SearchedObject).ToList();
        }
    }
}
