using FilmManagment.BL.Facades;
using FilmManagment.BL.Models.DetailModels;
using FilmManagment.GUI.Messages;
using FilmManagment.GUI.Services;
using FilmManagment.GUI.ViewModels.Interfaces;
using FilmManagment.GUI.Wrappers;
using FilmManagment.GUI.Extensions;
using System;
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

            EditButtonCommand = new RelayCommand(OnEditButtonCommandExecute);
            SaveButtonCommand = new RelayCommand(Save, CanSave);

            GenreOptions = EnumExtensions.ConvertEnumToList<Genre>();
        }

        // Commands
        public ICommand EditButtonCommand { get; }
        public ICommand SaveButtonCommand { get; }


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
                OnPropertyChanged();
            }
        }

        public List<string> GenreOptions { get; set; }

        public ObservableCollection<ActorListModel> Actors { get; set; } = new ObservableCollection<ActorListModel>();
        public ObservableCollection<DirectorListModel> Directors { get; set; } = new ObservableCollection<DirectorListModel>();
        public ObservableCollection<RatingListModel> Ratings { get; set; } = new ObservableCollection<RatingListModel>();


        private bool saveButtonReady = false;


        #region Actions triggered by RelayCommand

        private void OnEditButtonCommandExecute()
        {
            ReadOnlyTextBoxes = false;
            ComboBoxEnabled = true;
            saveButtonReady = true;
        }

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

        private void Save()
        {
            usedFacade.Save(Model);
            usedMediator.Send(new UpdateMessage<FilmWrappedModel> { Model = Model });
            ReadOnlyTextBoxes = true;
            ComboBoxEnabled = false;
            saveButtonReady = false;
        }

        #endregion

        public void Load(Guid id)
        {
            Model = usedFacade.GetById(id);
            Actors.Clear();
            Directors.Clear();
            Ratings.Clear();
            
            // TODO: add actors and directors to observable collections
        }

        private void CreateNewWrappedModel(NewMessage<FilmWrappedModel> _)
        {
            Model = new FilmDetailModel();
            ReadOnlyTextBoxes = false;
            ComboBoxEnabled = true;
            saveButtonReady = true;
            SelectedGenre = GenreOptions[0];
        }

        private void PrepareFilm(SelectedMessage<FilmWrappedModel> film)
        {
            Load(film.Id);
            ReadOnlyTextBoxes = true;
            ComboBoxEnabled = false;
            SelectedGenre = GenreOptions[GenreOptions.IndexOf(Model.GenreOfFilm.ToString())];
        }
    }
}
