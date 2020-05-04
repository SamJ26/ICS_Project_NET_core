using FilmManagment.BL.Facades;
using FilmManagment.BL.Models.DetailModels;
using FilmManagment.GUI.Messages;
using FilmManagment.GUI.Services;
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
        private readonly FilmFacade usedFacade;

        public FilmDetailViewModel(IMediator mediator,
                                   FilmFacade facade)
            
        {
            usedMediator = mediator;
            usedFacade = facade;

            usedMediator.Register<NewMessage<FilmWrappedModel>>(CreateNewWrappedModel);
            usedMediator.Register<SelectedMessage<FilmWrappedModel>>(PrepareFilm);

            EditButtonCommand = new RelayCommand(EnableTextBoxes);
            SaveButtonCommand = new RelayCommand(Save, CanSave);

            ActorSelectedCommand = new RelayCommand<FilmActorWrappedModel>(ActorSelected);
            RemoveActorButtonCommand = new RelayCommand(RemoveActorFromList, RemoveActorEnabled);

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
            usedFacade.Save(Model);
            usedMediator.Send(new UpdateMessage<FilmWrappedModel> { Model = Model });
            ReadOnlyTextBoxes = true;
            ComboBoxEnabled = false;
            saveButtonReady = false;
        }

        // Execute on RemoveActorButtonCommand
        private void RemoveActorFromList()
        {
            // TODO: finish

            //var itemInCollection = Model.Actors.SingleOrDefault(actor => actor.Id == selectedActor.Id);
            //Model.Actors.Remove(itemInCollection);
            //usedFacade.Save(Model);
        }

        // Execute on ActorSelectedCommand
        private void ActorSelected(FilmActorWrappedModel filmActorWrappedModel)
        {
            selectedActor = filmActorWrappedModel;
            actorSelected = true;
        }

        #endregion

        private bool RemoveActorEnabled() => actorSelected ? true : false;

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
            Model = usedFacade.GetById(id);

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
            ReadOnlyTextBoxes = true;
            ComboBoxEnabled = false;
            saveButtonReady = false;
            SelectedGenre = GenreOptions[GenreOptions.IndexOf(Model.GenreOfFilm.ToString())];
            filmLength = Model.LengthInMinutes.ToString();
        }
    }
}
