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

namespace FilmManagment.GUI.ViewModels
{
    public class FilmDetailViewModel : ViewModelBase, IFilmDetailViewModel
    {
        private readonly IMediator usedMediator;
        private readonly FilmFacade usedFilmFacade;
        private readonly FilmActorFacade usedFilmActorFacade;
        private readonly FilmDirectorFacade usedFilmDirectorFacade;
        private readonly IConnectionService usedConnectionService;
        private readonly ISelectActorViewModel usedSelectActorViewModel;
        private readonly ISelectDirectorViewModel usedSelectDirectorViewModel;

        public FilmDetailViewModel(IMediator mediator,
                                   FilmFacade filmFacade,
                                   FilmActorFacade filmActorFacade,
                                   FilmDirectorFacade filmDirectorFacade,
                                   IConnectionService connectionService,
                                   ISelectActorViewModel selectActorViewModel,
                                   ISelectDirectorViewModel selectDirectorViewModel)
            
        {
            usedMediator = mediator;
            usedFilmFacade = filmFacade;
            usedFilmActorFacade = filmActorFacade;
            usedFilmDirectorFacade = filmDirectorFacade;
            usedConnectionService = connectionService;
            usedSelectActorViewModel = selectActorViewModel;
            usedSelectDirectorViewModel = selectDirectorViewModel;

            mediator.Register<NewMessage<FilmWrappedModel>>(CreateNewWrappedModel);
            mediator.Register<SelectedMessage<FilmWrappedModel>>(PrepareFilm);
            mediator.Register<MoveFromDetailToDetailMessage<FilmActorWrappedModel>>(PrepareFilm);
            mediator.Register<MoveFromDetailToDetailMessage<FilmDirectorWrappedModel>>(PrepareFilm);

            mediator.Register<AddPersonToFilmMessage<ActorWrappedModel>>(AddActorToFilm);
            mediator.Register<AddPersonToFilmMessage<DirectorWrappedModel>>(AddDirectorToFilm);

            EditButtonCommand = new RelayCommand(EnableTextBoxes);
            SaveButtonCommand = new RelayCommand(Save, CanSave);

            ActorSelectedCommand = new RelayCommand<FilmActorWrappedModel>(ActorSelected);
            RemoveActorButtonCommand = new RelayCommand(RemoveActorFromList, RemoveActorEnabled);
            AddActorButtonCommand = new RelayCommand(ShowActors);

            DirectorSelectedCommand = new RelayCommand<FilmDirectorWrappedModel>(DirectorSelected);
            RemoveDirectorButtonCommand = new RelayCommand(RemoveDirectorFromList, RemoveDirectorEnabled);
            AddDirectorButtonCommand = new RelayCommand(ShowDirectors);

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


        public ObservableCollection<FilmActorWrappedModel> Actors { get; set; } = new ObservableCollection<FilmActorWrappedModel>();
        public ObservableCollection<FilmDirectorWrappedModel> Directors { get; set; } = new ObservableCollection<FilmDirectorWrappedModel>();
        public ObservableCollection<RatingWrappedModel> Ratings { get; set; } = new ObservableCollection<RatingWrappedModel>();
        public List<string> GenreOptions { get; set; }


        private bool saveButtonReady = false;
        private FilmActorWrappedModel selectedActor;
        private FilmDirectorWrappedModel selectedDirector;
        private RatingWrappedModel selectedRating;
        private bool actorSelected = false;
        private bool directorSelected = false;
        private bool ratingSelected = false;


        private string filmLength { get; set; }
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

        // Execute on RemoveActorButtonCommand
        private void RemoveActorFromList()
        {
            Actors.Remove(Actors.Single(item => item.Id == selectedActor.Id));
            usedFilmActorFacade.Delete(selectedActor.Id);
        }

        // Execute on ActorSelectedCommand
        private void ActorSelected(FilmActorWrappedModel filmActorWrappedModel)
        {
            selectedActor = filmActorWrappedModel;
            actorSelected = true;
        }

        // Execute on AddActorButtonCommand
        private void ShowActors() => usedConnectionService.ShowSelectiveWindow(usedSelectActorViewModel);

        // Execute on RemoveDirectorButtonCommand
        private void RemoveDirectorFromList()
        {
            Directors.Remove(Directors.Single(item => item.Id == selectedDirector.Id));
            usedFilmDirectorFacade.Delete(selectedDirector.Id);
        }

        // Execute on DirectorSelectedCommand
        private void DirectorSelected(FilmDirectorWrappedModel filmDirectorWrappedModel)
        {
            selectedDirector = filmDirectorWrappedModel;
            directorSelected = true;
        }

        // Execute on AddDirectorButtonCommand
        private void ShowDirectors() => usedConnectionService.ShowSelectiveWindow(usedSelectDirectorViewModel);

        #endregion

        private void AddActorToFilm(AddPersonToFilmMessage<ActorWrappedModel> selectedActor)
        {
            var filmActorListModel = new FilmActorListModel()
            {
                ActorId = selectedActor.Id,
                FilmId = Model.Id,
                FilmName = Model.OriginalName,
            };
            Model.Actors.Add(filmActorListModel);
            usedFilmFacade.Save(Model);

            // TODO: solve reloading list after adding actor
        }

        private void AddDirectorToFilm(AddPersonToFilmMessage<DirectorWrappedModel> selectedDirector)
        {
            var filmDirectorListModel = new FilmDirectorListModel()
            {
                DirectorId = selectedDirector.Id,
                FilmId = Model.Id,
                FilmName = Model.OriginalName,
            };
            Model.Directors.Add(filmDirectorListModel);
            usedFilmFacade.Save(Model);

            // TODO: solve reloading list after adding actor
        }

        private bool RemoveActorEnabled() => actorSelected ? true : false;

        private bool RemoveDirectorEnabled() => directorSelected ? true : false;

        private bool CanSave()
        {
            if (saveButtonReady &&
                Model != null &&
                !string.IsNullOrWhiteSpace(Model.OriginalName) &&
                !string.IsNullOrWhiteSpace(Model.CzechName) &&
                !string.IsNullOrWhiteSpace(Model.CountryOfOrigin) &&
                !string.IsNullOrWhiteSpace(Model.Description) &&
                Model.GenreOfFilm != Genre.Undefined &&
                Model.LengthInMinutes != TimeSpan.Zero)
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

        private void PrepareFilm(SelectedMessage<FilmWrappedModel> film)
        {
            Load(film.Id);
        }

        private void PrepareFilm(MoveFromDetailToDetailMessage<FilmActorWrappedModel> film)
        {
            Load(film.Id);
        }

        private void PrepareFilm(MoveFromDetailToDetailMessage<FilmDirectorWrappedModel> film)
        {
            Load(film.Id);
        }
    }
}
