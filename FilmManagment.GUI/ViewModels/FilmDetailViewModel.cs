using FilmManagment.BL.Facades;
using FilmManagment.BL.Models.DetailModels;
using FilmManagment.GUI.Messages;
using FilmManagment.GUI.Services;
using FilmManagment.GUI.Services.ConnectionService;
using FilmManagment.GUI.ViewModels.Interfaces;
using FilmManagment.GUI.Wrappers;
using FilmManagment.GUI.Extensions;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Input;
using FilmManagment.DAL.Enums;
using FilmManagment.GUI.Commands;
using System.Collections.ObjectModel;
using FilmManagment.BL.Models.ListModels;
using FilmManagment.GUI.Services.RatingCreationService;

namespace FilmManagment.GUI.ViewModels
{
    public class FilmDetailViewModel : ViewModelBase, IFilmDetailViewModel
    {
        private readonly IMediator usedMediator;
        private readonly FilmFacade usedFilmFacade;
        private readonly FilmActorFacade usedFilmActorFacade;
        private readonly FilmDirectorFacade usedFilmDirectorFacade;
        private readonly RatingFacade usedRatingFacade;
        private readonly IConnectionService usedConnectionService;
        private readonly ISelectActorViewModel usedSelectActorViewModel;
        private readonly ISelectDirectorViewModel usedSelectDirectorViewModel;
        private readonly IRatingCreationService usedRatingCreationService;

        public FilmDetailViewModel(IMediator mediator,
                                   FilmFacade filmFacade,
                                   FilmActorFacade filmActorFacade,
                                   FilmDirectorFacade filmDirectorFacade,
                                   RatingFacade ratingFacade,
                                   IConnectionService connectionService,
                                   ISelectActorViewModel selectActorViewModel,
                                   ISelectDirectorViewModel selectDirectorViewModel,
                                   IRatingCreationService ratingCreationService)     
        {
            usedMediator = mediator;
            usedFilmFacade = filmFacade;
            usedFilmActorFacade = filmActorFacade;
            usedFilmDirectorFacade = filmDirectorFacade;
            usedRatingFacade = ratingFacade;
            usedConnectionService = connectionService;
            usedSelectActorViewModel = selectActorViewModel;
            usedSelectDirectorViewModel = selectDirectorViewModel;
            usedRatingCreationService = ratingCreationService;

            mediator.Register<NewMessage<FilmWrappedModel>>(CreateNewWrappedModel);
            mediator.Register<SelectedMessage<FilmWrappedModel>>(PrepareFilm);
            mediator.Register<MoveToDetailMessage<FilmActorWrappedModel>>(PrepareFilm);
            mediator.Register<MoveToDetailMessage<FilmDirectorWrappedModel>>(PrepareFilm);
            mediator.Register<MoveToDetailMessage<FilmWrappedModel>>(PrepareFilm);
            mediator.Register<AddPersonToFilmMessage<ActorWrappedModel>>(AddActorToFilm);
            mediator.Register<AddPersonToFilmMessage<DirectorWrappedModel>>(AddDirectorToFilm);
            mediator.Register<AddRatingToFilmMessage<RatingWrappedListModel>>(AddRatingToFilm);

            EditButtonCommand = new RelayCommand(EnableTextBoxes);
            SaveButtonCommand = new RelayCommand(Save, CanSave);
            ActorSelectedCommand = new RelayCommand<FilmActorWrappedModel>(ActorSelected);
            RemoveActorButtonCommand = new RelayCommand(RemoveActorFromList, RemoveActorEnabled);
            AddActorButtonCommand = new RelayCommand(ShowActors);
            DirectorSelectedCommand = new RelayCommand<FilmDirectorWrappedModel>(DirectorSelected);
            RemoveDirectorButtonCommand = new RelayCommand(RemoveDirectorFromList, RemoveDirectorEnabled);
            AddDirectorButtonCommand = new RelayCommand(ShowDirectors);
            RatingSelectedCommand = new RelayCommand<RatingWrappedModel>(RatingSelected);
            RemoveRatingButtonCommand = new RelayCommand(RemoveRatingFromList, RemoveRatingEnabled);
            AddRatingButtonCommand = new RelayCommand(ShowRatingCreationWindow);

            ActorListDoubleClickCommand = new RelayCommand<FilmActorWrappedModel>(MoveToActorDetail);
            DirectorListDoubleClickCommand = new RelayCommand<FilmDirectorWrappedModel>(MoveToDirectorDetail);

            GenreOptions = EnumExtensions.ConvertEnumToList<Genre>();
        }

        // Commands
        public ICommand EditButtonCommand { get; }
        public ICommand SaveButtonCommand { get; }
        public ICommand AddRatingButtonCommand { get; }
        public ICommand AddActorButtonCommand { get; }
        public ICommand AddDirectorButtonCommand { get; }
        public ICommand RemoveRatingButtonCommand { get; }
        public ICommand RemoveActorButtonCommand { get; }
        public ICommand RemoveDirectorButtonCommand { get; }
        public ICommand ActorSelectedCommand { get; }
        public ICommand DirectorSelectedCommand { get; }
        public ICommand RatingSelectedCommand { get; }
        public ICommand ActorListDoubleClickCommand { get;  }
        public ICommand DirectorListDoubleClickCommand { get;  }


        public ObservableCollection<FilmActorWrappedModel> Actors { get; set; } = new ObservableCollection<FilmActorWrappedModel>();
        public ObservableCollection<FilmDirectorWrappedModel> Directors { get; set; } = new ObservableCollection<FilmDirectorWrappedModel>();
        public ObservableCollection<RatingWrappedModel> Ratings { get; set; } = new ObservableCollection<RatingWrappedModel>();
        public List<string> GenreOptions { get; set; }


        private bool saveButtonReady = false;
        private FilmActorWrappedModel selectedActor;
        private FilmDirectorWrappedModel selectedDirector;
        private RatingWrappedModel selectedRating;


        #region Properties with private fields

        private string filmLength;
        public string FilmLength
        {
            get => filmLength;
            set
            {
                filmLength = value;
                OnPropertyChanged();
            }
        }

        private FilmWrappedModel model;
        public FilmWrappedModel Model
        {
            get => model;
            set
            {
                model = value;
                OnPropertyChanged();
            }
        }

        private bool readOnlyTextBoxes;
        public bool ReadOnlyTextBoxes
        {
            get => readOnlyTextBoxes;
            set
            {
                readOnlyTextBoxes = value;
                OnPropertyChanged();
            }
        }

        private bool comboBoxEnabled;
        public bool ComboBoxEnabled
        {
            get => comboBoxEnabled;
            set
            {
                comboBoxEnabled = value;
                OnPropertyChanged();
            }
        }

        private string selectedGenre;
        public string SelectedGenre
        {
            get => selectedGenre;
            set
            {
                selectedGenre = value;
                Model.GenreOfFilm = (Genre)GenreOptions.IndexOf(selectedGenre);
                OnPropertyChanged();
            }
        }

        #endregion

        #region Actions to execute on button click

        // Execute on EditButtonCommand
        private void EnableTextBoxes()
        {
            ReadOnlyTextBoxes = false;
            ComboBoxEnabled = true;
            saveButtonReady = true;
        }

        // Execute on SaveButtonCommand
        private void Save()
        {
            Model.LengthInMinutes = TimeSpan.Parse(filmLength);
            usedFilmFacade.Save(Model);
            usedMediator.Send(new UpdateMessage<FilmWrappedModel> { Model = Model });
            ReadOnlyTextBoxes = true;
            ComboBoxEnabled = false;
            saveButtonReady = false;
        }

        #endregion

        #region Actions related to collection of Actors

        // Execute on ActorSelectedCommand
        private void ActorSelected(FilmActorWrappedModel filmActorWrappedModel) => selectedActor = filmActorWrappedModel;

        // Execute on RemoveActorButtonCommand
        private void RemoveActorFromList()
        {
            Actors.Remove(Actors.Single(item => item.Id == selectedActor.Id));
            usedFilmActorFacade.Delete(selectedActor.Id);
            selectedActor = null;
            Load(Model.Id);
        }

        // Execute on AddActorButtonCommand
        private void ShowActors() => usedConnectionService.ShowSelectiveWindow(usedSelectActorViewModel);

        #endregion

        #region Actions related to collection of Directors

        // Execute on DirectorSelectedCommand
        private void DirectorSelected(FilmDirectorWrappedModel filmDirectorWrappedModel) => selectedDirector = filmDirectorWrappedModel;

        // Execute on RemoveDirectorButtonCommand
        private void RemoveDirectorFromList()
        {
            Directors.Remove(Directors.Single(item => item.Id == selectedDirector.Id));
            usedFilmDirectorFacade.Delete(selectedDirector.Id);
            selectedDirector = null;
            Load(Model.Id);
        }

        // Execute on AddDirectorButtonCommand
        private void ShowDirectors() => usedConnectionService.ShowSelectiveWindow(usedSelectDirectorViewModel);

        #endregion

        #region Actions related to collection of Ratings

        // Execute on RatingSelectedCommand
        private void RatingSelected(RatingWrappedModel ratingWrappedModel) => selectedRating = ratingWrappedModel;

        // Execute on RemoveRatingButtonCommand
        private void RemoveRatingFromList()
        {
            Ratings.Remove(Ratings.Single(item => item.Id == selectedRating.Id));
            usedRatingFacade.Delete(selectedRating.Id);
            selectedRating = null;
            Load(Model.Id);
        }

        // Execute on AddRatingButtonCommand
        private void ShowRatingCreationWindow() => usedRatingCreationService.ShowWindow();

        #endregion

        private void MoveToActorDetail(FilmActorWrappedModel selectedFilmActorWrappedModel)
        {
            usedMediator.Send(new MoveToDetailMessage<ActorWrappedModel> { Id = selectedFilmActorWrappedModel.ActorId });
            selectedActor = null;
        }

        private void MoveToDirectorDetail(FilmDirectorWrappedModel selectedFilmDirectorWrappedModel)
        {
            usedMediator.Send(new MoveToDetailMessage<DirectorWrappedModel> { Id = selectedFilmDirectorWrappedModel.DirectorId });
            selectedDirector = null;
        }

        private void AddActorToFilm(AddPersonToFilmMessage<ActorWrappedModel> actor)
        {
            if (Model.Actors.All(item => item.ActorId != actor.Id))
            {
                var filmActorListModel = new FilmActorListModel()
                {
                    ActorId = actor.Id,
                    FilmId = Model.Id,
                    FilmName = Model.OriginalName,
                    ActorName = actor.PersonName
                };
                Model.Actors.Add(filmActorListModel);
                usedFilmFacade.Save(Model);
                Load(Model.Id);
            }
        }

        private void AddDirectorToFilm(AddPersonToFilmMessage<DirectorWrappedModel> director)
        {
            if (Model.Directors.All(item => item.DirectorId != director.Id))
            {
                var filmDirectorListModel = new FilmDirectorListModel()
                {
                    DirectorId = director.Id,
                    FilmId = Model.Id,
                    FilmName = Model.OriginalName,
                    DirectorName = director.PersonName
                };
                Model.Directors.Add(filmDirectorListModel);
                usedFilmFacade.Save(Model);
                Load(Model.Id);
            }
        }

        private void AddRatingToFilm(AddRatingToFilmMessage<RatingWrappedListModel> newRating)
        {
            var ratingListModel = new RatingListModel()
            {
                RatingInPercents = newRating.RatingInPercents,
                TextRating = newRating.TextRating
            };
            Model.Ratings.Add(ratingListModel);
            usedFilmFacade.Save(Model);
            Load(Model.Id);
        }

        private bool RemoveActorEnabled() => selectedActor != null ? true : false;

        private bool RemoveDirectorEnabled() => selectedDirector != null ? true : false;

        private bool RemoveRatingEnabled() => selectedRating != null ? true : false;

        private bool CanSave()
        {
            if (saveButtonReady &&
                Model != null &&
                !string.IsNullOrWhiteSpace(Model.OriginalName) &&
                !string.IsNullOrWhiteSpace(Model.CzechName) &&
                !string.IsNullOrWhiteSpace(Model.CountryOfOrigin) &&
                //!string.IsNullOrWhiteSpace(Model.Description) &&          // TODO
                Model.GenreOfFilm != Genre.Undefined &&
                !FilmLength.Equals("00:00:00"))
                return true;
            return false;
        }

        public void Load(Guid id)
        {
            Model = usedFilmFacade.GetById(id);

            ReadOnlyTextBoxes = true;
            ComboBoxEnabled = false;
            saveButtonReady = false;
            SelectedGenre = GenreOptions[GenreOptions.IndexOf(Model.GenreOfFilm.ToString())];
            filmLength = Model.LengthInMinutes.ToString();

            Actors.Clear();
            Actors.AddList(Model.Actors);

            Directors.Clear();
            Directors.AddList(Model.Directors);

            Ratings.Clear();
            Ratings.AddList(Model.Ratings);
        }

        private void CreateNewWrappedModel(NewMessage<FilmWrappedModel> _)
        {
            Model = new FilmDetailModel();
            ReadOnlyTextBoxes = false;
            ComboBoxEnabled = true;
            saveButtonReady = true;
            SelectedGenre = GenreOptions[0];
            filmLength = Model.LengthInMinutes.ToString();
        }

        private void PrepareFilm(SelectedMessage<FilmWrappedModel> film) => Load(film.Id);

        private void PrepareFilm(MoveToDetailMessage<FilmActorWrappedModel> film) => Load(film.Id);

        private void PrepareFilm(MoveToDetailMessage<FilmDirectorWrappedModel> film) => Load(film.Id);

        private void PrepareFilm(MoveToDetailMessage<FilmWrappedModel> film) => Load(film.Id);
    }
}
