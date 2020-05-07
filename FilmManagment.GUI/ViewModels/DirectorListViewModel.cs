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
    public class DirectorListViewModel : ViewModelBase, IDirectorListViewModel
    {
        private readonly IMediator usedMediator;
        private readonly IWarningService usedWarningService;
        private readonly DirectorFacade usedFacade;

        public DirectorListViewModel(IMediator mediator,
                                     IWarningService warningService,
                                     DirectorFacade facade)
        {
            usedMediator = mediator;
            usedWarningService = warningService;
            usedFacade = facade;

            mediator.Register<YES_WarningResultMessage<DirectorWrappedModel>>(DeleteDirector);
            mediator.Register<NO_WarningResultMessage<DirectorWrappedModel>>(UpdateDirectors);
            mediator.Register<UpdateMessage<DirectorWrappedModel>>(UpdateDirectors);

            DirectorSelectedCommand = new RelayCommand<DirectorListModel>(SendDirectorSelectedMessage);
            AddButtonCommand = new RelayCommand(SendDirectorNewMessage);
            DeleteButtonCommand = new RelayCommand(ExecuteWarning, IsEnabled_DeleteDetailButton);
            DetailButtonCommand = new RelayCommand(SendDetailButtonPushedMessage, IsEnabled_DeleteDetailButton);
            RefreshButtonCommand = new RelayCommand(Refresh);
            SearchButtonCommand = new RelayCommand(StartSearching);

            SearchedObject = defaultSearchingBoxMessage;
            SearchingOptions = new List<string>() { "First name", "Second name" };
            SelectedOption = SearchingOptions[1];

            Load();
        }

        // Commands
        public ICommand DirectorSelectedCommand { get; }
        public ICommand AddButtonCommand { get; }
        public ICommand DeleteButtonCommand { get; }
        public ICommand DetailButtonCommand { get; }
        public ICommand RefreshButtonCommand { get; }
        public ICommand SearchButtonCommand { get; }

        public ObservableCollection<DirectorListModel> Directors { get; set; } = new ObservableCollection<DirectorListModel>();
        public List<string> SearchingOptions { get; set; }


        private readonly string defaultSearchingBoxMessage = "What are you looking for?";

        private DirectorListModel selectedDirector;

        private ICollection<DirectorListModel> foundDirectors;


        private string searchedObject;
        public string SearchedObject
        {
            get => searchedObject;
            set
            {
                searchedObject = value;
                OnPropertyChanged();
            }
        }

        private string selectedOption;
        public string SelectedOption
        {
            get => selectedOption;
            set
            {
                selectedOption = value;
                OnPropertyChanged();
            }
        }

        #region Actions to execute on button click

        // Execute on DirectorSelectedCommand
        private void SendDirectorSelectedMessage(DirectorListModel directorListModel)
        {
            usedMediator.Send(new SelectedMessage<DirectorWrappedModel> { Id = directorListModel.Id });
            selectedDirector = directorListModel;
        }

        // Execute on AddButtonCommand
        private void SendDirectorNewMessage()
        {
            usedMediator.Send(new NewMessage<DirectorWrappedModel>());
            selectedDirector = null;
        }

        // Execute on DeleteButtonCommand
        private void ExecuteWarning() => usedWarningService.ShowWarning(typeof(DirectorWrappedModel));

        // Execute on DetailButtonCommand
        private void SendDetailButtonPushedMessage()
        {
            usedMediator.Send(new DetailButtonPushedMessage<DirectorWrappedModel>());
            selectedDirector = null;
        }

        //Execute on RefreshButtonCommand
        private void Refresh()
        {
            Load();
            selectedDirector = null;
            SearchedObject = defaultSearchingBoxMessage;
        }

        // Execute on SearchButtonCommand
        private void StartSearching()
        {
            if (!string.IsNullOrEmpty(SearchedObject) && !string.IsNullOrWhiteSpace(SearchedObject))
            {
                foundDirectors = Search();
                Directors.Clear();
                Directors.AddList(foundDirectors);
            }
        }

        #endregion

        private bool IsEnabled_DeleteDetailButton() => selectedDirector == null ? false : true;

        private void DeleteDirector(YES_WarningResultMessage<DirectorWrappedModel> _)
        {
            usedFacade.Delete(selectedDirector.Id);
            Load();
            selectedDirector = null;

            // TODO: sent message to update listViews in whole app
        }

        private void UpdateDirectors(IMessage _)
        {
            Load();
            selectedDirector = null;
        }

        public void Load()
        {
            Directors.Clear();
            var directorsFromDB = usedFacade.GetAllList();
            Directors.AddList(directorsFromDB);
        }

        private ICollection<DirectorListModel> Search()
        {
            var query = usedFacade.GetAllList();

            // Searching according to First name
            if (SelectedOption == SearchingOptions.ElementAt(0))
                return query.Where(director => director.FirstName == SearchedObject).ToList();

            // Default: Searching according to Second name
            else
                return query.Where(director => director.SecondName == SearchedObject).ToList();
        }
    }
}
